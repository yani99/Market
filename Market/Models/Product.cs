using System;
using System.Collections.Generic;

namespace Market.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int QualityId { get; set; }
        public int ShipperId { get; set; }

        public virtual Quality Quality { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
