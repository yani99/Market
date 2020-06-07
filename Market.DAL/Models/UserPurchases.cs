using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class UserPurchases
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime Date { get; set; }

        public virtual Order Order { get; set; }
    }
}
