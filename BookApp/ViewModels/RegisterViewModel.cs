using BookApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BookApp.Models;
using Xamarin.Forms;
using AppContext = BookApp.Services.AppContext;

namespace BookApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public Command RegisterCommand { get; }
        private readonly User _user;
        private String _password2 { get; set; }
        private AppContext _context;

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
            _user = new User();
            _context = new AppContext();
        }

        private async void OnRegisterClicked(object obj)
        {
            RegisterUser();
        }


        private bool RegisterUser()
        {
            if (String.IsNullOrWhiteSpace(Email) || String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(Password2))
                return false;

            if (IsValidEmail(Email) && Password.Equals(Password2))
            {
                if (IsUserExist(Email))
                    return false;

                ///TODO - DI context
                _context.Users.Add(_user);


                return true;
            }

            return false;
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
