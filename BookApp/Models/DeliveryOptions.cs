using System;
using System.Collections.Generic;

namespace BookApp.Models
{
    public class DeliveryOptions
    {
        public int Id { get; set; }

        public List<DeliveryOption> DeliveryOpts { get; set; }
    }
}
