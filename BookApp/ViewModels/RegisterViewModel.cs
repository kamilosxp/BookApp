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

#pragma warning disable CS0108 // 'RegisterViewModel.PropertyChanged' hides inherited member 'BaseViewModel.PropertyChanged'. Use the new keyword if hiding was intended.
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // 'RegisterViewModel.PropertyChanged' hides inherited member 'BaseViewModel.PropertyChanged'. Use the new keyword if hiding was intended.

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

#pragma warning disable CS0108 // 'RegisterViewModel.OnPropertyChanged(string)' hides inherited member 'BaseViewModel.OnPropertyChanged(string)'. Use the new keyword if hiding was intended.
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
#pragma warning restore CS0108 // 'RegisterViewModel.OnPropertyChanged(string)' hides inherited member 'BaseViewModel.OnPropertyChanged(string)'. Use the new keyword if hiding was intended.
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
