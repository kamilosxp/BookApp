using System;
using System.ComponentModel;
using BookApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp.Views
{
    public partial class SettingsView : ContentPage
    {
        public SettingsView()
        {
            InitializeComponent();
            BindingContext = new SettingsViewModel();
        }
    }
}
