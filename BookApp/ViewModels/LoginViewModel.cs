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
using AppContext = BookApp.Services.AppContext;

namespace BookApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public INavigation Navigation { get; set; }
        private readonly User _user;
        private readonly AppContext _context;

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);

            _user = new User();
            _context = new AppContext();
        }

        private async void OnLoginClicked(object obj)
        {
            if (IsUserExist(Email))
            {
                if (CheckPassword(Password, Email))
                {
                    ///TODO - kolejny ekran
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Bład!", "Nieprawidłowe hasło!", "OK");
                }
            }
            else
            {
                ///TODO - przeniesc do resource
                await Application.Current.MainPage.DisplayAlert("Bład!", "Nieprawidłowy adres e-mail!", "OK");
            }

        }

        private bool IsUserExist(string email)
        {
            var users = _context.Users.ToList();
            var exist = users.Exists(a => a.Email == email);

            return exist != true;
        }

        private bool CheckPassword(string enteredPass, string email)
        {
            var users = _context.Users.ToList();
            var user = users.FirstOrDefault(a => a.Email == email);
            var correctPassword = user != null && user.Password == enteredPass;

            return correctPassword;
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
