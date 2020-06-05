using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class AspNetUserLogins
    {
        public virtual AspNetUsers User { get; set; }
    }
}
