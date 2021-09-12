using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class UserAddressViewModel : BaseViewModel
    {
        public UserAddressViewModel()
        {
            Title = "Twoje dane";
        }

        public ICommand OpenWebCommand { get; }
    }
}
