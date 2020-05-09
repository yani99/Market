using System;
using System.Collections.Generic;

namespace Market.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Orders>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
