using System;
using System.Linq;
using System.Windows.Input;
using BookApp.Helpers;
using BookApp.Models;
using BookApp.Services;
using BookApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;

namespace BookApp.ViewModels
{
    public class UserAddressViewModel : BaseViewModel
    {
        private readonly BookAppContext _context;
        private readonly IUserService _userService;
        private User _user;

        public UserAddressViewModel()
        {
            Title = "Twoje dane";
            _context = new BookAppContext();
            _userService = new UserService(_context);
            _user = _context.Users
                .Include("Address")
                .FirstOrDefault(a => a.Email == ActiveUser.GetUser().Email);
            if (_user.Address == null)
                _user.Address = new Address();

            SaveCommand = new Command(OnSaveClicked);
        }

        public ICommand OpenWebCommand { get; }
        public ICommand SaveCommand { get; }


        public string Name
        {
            get => _user.Address.Name;
            set
            {
                _user.Address.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get => _user.Address.Surname;
            set
            {
                _user.Address.Surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Address
        {
            get => _user.Address.Street;
            set
            {
                _user.Address.Street = value;
                OnPropertyChanged("Street");
            }
        }

        public string HouseAndFlatNumber
        {
            get => _user.Address.HouseAndFlatNumber;
            set
            {
                _user.Address.HouseAndFlatNumber = value;
                OnPropertyChanged("HouseAndFlatNumber");
            }
        }

        public string PostCode
        {
            get => _user.Address.ZIPCode;
            set
            {
                _user.Address.ZIPCode = value;
                OnPropertyChanged("ZIPCode");
            }
        }

        public string City
        {
            get => _user.Address.City;
            set
            {
                _user.Address.Name = value;
                OnPropertyChanged("City");
            }
        }

        private async void OnSaveClicked(object obj)
        {
            _context.SaveChanges();
            await Application.Current.MainPage.DisplayAlert("Zapisano!", "Pomyślnie zapisano zmiany!", "OK");
            Application.Current.MainPage = new MainView();
        }
    }
}
