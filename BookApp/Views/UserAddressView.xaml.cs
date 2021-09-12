using System;
using BookApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp.Views
{
    public partial class UserAddressView : ContentPage
    {
        public UserAddressView()
        {
            InitializeComponent();
            BindingContext = new UserAddressViewModel();
        }
    }
}