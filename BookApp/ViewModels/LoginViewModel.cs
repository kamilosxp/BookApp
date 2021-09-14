using BookApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BookApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Xamarin.Forms;
using BookAppContext = BookApp.Services.BookAppContext;
using BookApp.Services;

namespace BookApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public INavigation Navigation { get; set; }
        private readonly User _user;
        private readonly BookAppContext _context;
        private readonly IUserService _userService;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);

            _user = new User();
            _context = new BookAppContext();
            _userService = new UserService(_context);
        }

        private async void OnLoginClicked(object obj)
        {
            //To delete
            //Application.Current.MainPage = new MainView();

            if (_userService.IsUserExist(Email))
            {
                if (_userService.IsPasswordCorrect(Email, Password))
                {
                    Application.Current.MainPage = new MainView();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Błąd!", "Nieprawidłowe hasło!", "OK");
                }
            }
            else
            {
                ///TODO - przeniesc do resource
                await Application.Current.MainPage.DisplayAlert("Błąd!", "Nieprawidłowy adres e-mail!", "OK");
            }

        }

        private async void OnRegisterClicked(object obj)
        {
            Application.Current.MainPage = new RegisterView();
        }

        public string Email
        {
            get => _user.Email;
            set
            {
                _user.Email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password
        {
            get => _user.Password;
            set
            {
                _user.Password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
