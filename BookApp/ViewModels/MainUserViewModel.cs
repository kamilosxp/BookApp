using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BookApp.Models;
using BookApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookApp.ViewModels
{
    public class MainUserViewModel : BaseViewModel
    {
        private readonly BookAppContext _context;
        
        private Offer _offer;

        public MainUserViewModel()
        {
            Title = "Strona główna";
            _context = new BookAppContext();

            Offers = new ObservableCollection<Offer>();
            Offers = new ObservableCollection<Offer>(_context.Offers.Include("Book"));
        }


        public ObservableCollection<Offer> Offers { get; set; }
    }
}
