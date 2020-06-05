using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
