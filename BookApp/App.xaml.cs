using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookApp.Services;
using BookApp.Views;
using BookAppContext = BookApp.Services.BookAppContext;
using BookApp.Models;

namespace BookApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
