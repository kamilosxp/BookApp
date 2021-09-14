using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BookApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class MainUserViewModel : BaseViewModel
    {
        public MainUserViewModel()
        {
            Title = "Strona główna";

            //Offers = new ObservableCollection<Offer>();

            //var book = new Book();
            //book.Name = "ksiazka123";
            //book.Price = 50.0f;
            //book.ImageURL = "https://static.wikia.nocookie.net/harrypotter/images/7/7b/Harry01english.jpg";

            //var offer = new Offer();
            //offer.Book = book;

            //for(int i=0; i < 20; i++)
            //{
            //    Offers.Add(offer);
            //}

        }


        public ObservableCollection<Offer> Offers { get; set; }
    }
}
