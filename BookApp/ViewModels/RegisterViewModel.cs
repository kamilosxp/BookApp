using BookApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Command RegisterCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            new Exception("dsadsad");
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }


        private void RegisterUser()
        {

        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
