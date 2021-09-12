﻿using System;
using BookApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp.Views
{
    public partial class AddBookView : ContentPage
    {
        public AddBookView()
        {
            InitializeComponent();
            BindingContext = new AddBookViewModel();
        }
    }
}