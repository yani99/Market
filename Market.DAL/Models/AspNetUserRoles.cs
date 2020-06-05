using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class AspNetUserRoles
    {
        public virtual AspNetRoles Role { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
