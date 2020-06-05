using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class Quality
    {
        public Quality()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Quality1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
