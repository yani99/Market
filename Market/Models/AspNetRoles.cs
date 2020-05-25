using System;
using System.Collections.Generic;

namespace Market.Models
{
    public partial class AspNetRoles
    {
        public AspNetRoles()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaims>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }
        public virtual ICollection<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
