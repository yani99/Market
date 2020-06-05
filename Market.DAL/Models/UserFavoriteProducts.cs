using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class UserFavoriteProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }

        public virtual Product Product { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
