using System;
using System.ComponentModel;
using BookApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp.Views
{
    public partial class OrdersView : ContentPage
    {
        public OrdersView()
        {
            InitializeComponent();
            BindingContext = new OrdersViewModel();
        }
    }
}
