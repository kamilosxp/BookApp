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

namespace BookApp.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private readonly BookAppContext _context;
        private Offer _offer;

        public OrderViewModel()
        {
            Title = "Zamówienie";
            _context = new BookAppContext();

            Offers = new ObservableCollection<Offer>();
            Offers = new ObservableCollection<Offer>(_context.Offers.Include("Book")
                .Where(a => a.Buyer != null && a.Buyer == ActiveUser.GetUser()));
        }


        public ObservableCollection<Offer> Offers { get; set; }
    }
}
