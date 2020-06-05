using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class UserOrders
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }

        public virtual Order Order { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
