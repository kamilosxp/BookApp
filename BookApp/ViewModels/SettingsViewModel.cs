using System;
using System.Windows.Input;
using BookApp.Helpers;
using BookApp.Services;
using BookApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private string _password, _password2;
        private BookAppContext _context;
        private IUserService _userService;

        public SettingsViewModel()
        {
            Title = "Ustawienia";
            ChangePasswordCommand = new Command(OnChangePasswordClicked);
            _context = new BookAppContext();
            _userService = new UserService(_context);
        }

        public ICommand ChangePasswordCommand { get; }

        private async void OnChangePasswordClicked(object obj)
        {
            if (Password.Equals(Password2))
            {
                _userService.ChangePassword(Password, ActiveUser.GetUser());
                await Application.Current.MainPage.DisplayAlert("Zapisano!", "Pomyślnie zapisano zmiany!", "OK");
                Application.Current.MainPage = new LoginPage();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
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
    }
}
