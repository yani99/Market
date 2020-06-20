using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            Order = new HashSet<Order>();
            Product = new HashSet<Product>();
            UserFavoriteProducts = new HashSet<UserFavoriteProducts>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Currency { get; set; }

        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<UserFavoriteProducts> UserFavoriteProducts { get; set; }
    }
}
