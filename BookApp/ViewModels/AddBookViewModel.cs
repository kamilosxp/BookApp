using System;
using System.Windows.Input;
using BookApp.Helpers;
using BookApp.Models;
using BookApp.Services;
using BookApp.Views;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class AddBookViewModel : BaseViewModel
    {
        private readonly BookAppContext _context;
        private readonly IUserService _userService;
        private User _user;
        private Book _book;
        private Offer _offer;

        public AddBookViewModel()
        {
            Title = "Wystaw książkę";

            _context = new BookAppContext();
            _userService = new UserService(_context);
            _user = ActiveUser.GetUser();
            _book = new Book();
            _offer = new Offer();

            AddCommand = new Command(OnAddClicked);
        }

        public ICommand AddCommand { get; } 

        private async void OnAddClicked(object obj)
        {
            ///TODO refactor
            _offer.Book = _book;
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            _offer.Latitude = position.Latitude;
            _offer.Longitude = position.Longitude;
            _offer.Date = DateTime.Now;

            _context.Offers.Add(_offer);
            _context.SaveChanges();

            await Application.Current.MainPage.DisplayAlert("Zapisano!", "Pomyślnie wystawiono książkę!", "OK");
            Application.Current.MainPage = new MainView();
        }

        public string Name
        {
            get => _book.Name;
            set
            {
                _book.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get => _offer.Description;
            set
            {
                _offer.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Price
        {
            get => _book.Price.ToString() ?? "";
            set
            {
                _book.Price = float.Parse(value);
                OnPropertyChanged("Price");
            }
        }
    }
}
