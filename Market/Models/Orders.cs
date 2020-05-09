using System;
using System.Collections.Generic;

namespace Market.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShipperId { get; set; }
        public string UserId { get; set; }
        public int QualityId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Quality Quality { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
