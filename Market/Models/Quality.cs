using System;
using System.Collections.Generic;

namespace Market.Models
{
    public partial class Quality
    {
        public Quality()
        {
            Orders = new HashSet<Orders>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Quality1 { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
