using System;
namespace BookApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string HouseAndFlatNumber { get; set; }
        public string City { get; set; }
        public string ZIPCode { get; set; }
    }
}
