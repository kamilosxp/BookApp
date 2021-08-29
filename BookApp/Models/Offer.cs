using System;
namespace BookApp.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public bool ForSale { get; set; }
        public bool OnLoan { get; set; }
        public float Price { get; set; }
        public float LoanTime { get; set; }

        public Book Book { get; set; }
        public Address Adress { get; set; }
        public User Author { get; set; }
        public DateTime Date { get; set; }
        public DeliveryOptions DeliveryOptions { get; set; }
    }
}
