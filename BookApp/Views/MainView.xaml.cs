﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : Shell
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}