using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class AddBookViewModel : BaseViewModel
    {
        public AddBookViewModel()
        {
            Title = "Wystaw książkę";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
