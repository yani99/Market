using System;
using System.Collections.Generic;

namespace Market.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Price { get; set; }
        public int? OrderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] ProfilePicture { get; set; }
        public int? ImageCollection { get; set; }
        public int? Quantity { get; set; }
        public int QualityId { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual Orders Orders { get; set; }
        public virtual Quality Quality { get; set; }


    }
}
