using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BookApp.Services;
using BookApp.Views;
using AppContext = BookApp.Services.AppContext;
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

            var db = new AppContext();

            var user = new User();
            user.Email = "dsad";

            db.Users.Add(user);
            db.SaveChanges();
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
