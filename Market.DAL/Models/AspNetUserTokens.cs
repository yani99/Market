using System;
using System.Collections.Generic;

namespace Market.DAL.Models
{
    public partial class AspNetUserTokens
    {
        public virtual AspNetUsers User { get; set; }
    }
}
