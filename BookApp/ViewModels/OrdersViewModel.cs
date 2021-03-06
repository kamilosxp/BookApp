using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BookApp.Models;
using BookApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BookApp.Helpers;
using BookApp.Views;

namespace BookApp.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        private readonly BookAppContext _context;
        private Offer _offer;
        public Command OpenOrderCommand { get; }

        public OrdersViewModel()
        {
            Title = "Twoje zamówienia";
            _context = new BookAppContext();

            OpenOrderCommand = new Command(OpenOrder);

            Offers = new ObservableCollection<Offer>();
            Offers = new ObservableCollection<Offer>(_context.Offers.Include("Book")
                .Where(a => a.Buyer != null && a.Buyer == ActiveUser.GetUser()));
        }


        public ObservableCollection<Offer> Offers { get; set; }

        private void OpenOrder(object obj)
        {
            Application.Current.MainPage = new OrderView();
        }
    }
}
