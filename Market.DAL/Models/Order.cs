using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            UserPurchases = new HashSet<UserPurchases>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public int ShipperId { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<UserPurchases> UserPurchases { get; set; }
    }
}
