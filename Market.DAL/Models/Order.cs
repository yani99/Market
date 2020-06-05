using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            UserOrders = new HashSet<UserOrders>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public int NumberOfPurchases { get; set; }
        public int ShipperId { get; set; }

        public virtual Shipper Shipper { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<UserOrders> UserOrders { get; set; }
    }
}
