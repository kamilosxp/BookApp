using System;
using System.ComponentModel;
using BookApp.ViewModels;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace BookApp.Views
{
    public partial class MainUserView : ContentPage
    {
        public MainUserView()
        {
            InitializeComponent();
            BindingContext = new MainUserViewModel();
            //map.MyLocationEnabled = true;

            Set();
        }

        public async void Set()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(50.049683, 19.944544),
                                                                  Distance.FromMiles(1)));

            Pin pin = new Pin
            {
                Label = "Santa Cruz",
                Address = "The city with a boardwalk",
                Type = PinType.Place,
                Position = new Position(50.049684, 19.944544)
            };
            map.Pins.Add(pin);

        }

    }
}
