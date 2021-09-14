using BookApp.Views;
using System.Linq;
using BookApp.Models;
using Xamarin.Forms;
using BookAppContext = BookApp.Services.BookAppContext;
using BookApp.Services;
using BookApp.Helpers;
using Microsoft.EntityFrameworkCore;

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
            Application.Current.MainPage = new MainView();

            if (_userService.IsUserExist(Email))
            {
                if (_userService.IsPasswordCorrect(Email, Password))
                {
                    ///TODO - we need pass model with relation tables
                    ///
                    //var user = _context.Users.FirstOrDefault(a => a.Email == Email)
                    ActiveUser.SetUser(_context.Users.Include("Address").FirstOrDefault(a=>a.Email == Email));
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
