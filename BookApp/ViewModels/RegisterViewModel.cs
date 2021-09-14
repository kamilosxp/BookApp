using BookApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BookApp.Models;
using Xamarin.Forms;
using BookAppContext = BookApp.Services.BookAppContext;
using BookApp.Services;
using BookApp.Helpers;

namespace BookApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }
        private readonly User _user;
        private string _password2 { get; set; }
        private BookAppContext _context;
        private readonly IUserService _userService;

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
            _user = new User();
            _context = new BookAppContext();
            _userService = new UserService(_context);
        }

        private async void OnRegisterClicked(object obj)
        {
            RegisterUser();
        }


        private async void RegisterUser()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(Email) || String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(Password2))
                    return;

                if (IsValidEmail(Email) && Password.Equals(Password2))
                {
                    //if (_userService.IsUserExist(Email))
                    //    throw new Exception("User already exist!");

                    ///TODO - DI context
                    var created = _userService.AddUser(_user);

                    if(created)
                    {
                        ActiveUser.SetUser(_user);
                        Application.Current.MainPage = new MainView();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Błąd!", "Nie udało utworzyć się konta!", "OK");
                    }
                }
            }
            catch(Exception)
            {

            }
        }

        private bool IsUserExist(string email)
        {
            var user = _context.Users.FirstOrDefault(a => a.Email == email);
            if (user == null)
                return true;

            return false;
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

        public string Password2
        {
            get => _password2;
            set
            {
                _password2 = value;
                OnPropertyChanged("Password2");
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
