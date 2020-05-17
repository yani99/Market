using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Market.Models
{
    public partial class MarketDBContext : IdentityDbContext<AspNetUsers, AspNetRoles, string, AspNetUserClaims,
        AspNetUserRoles, AspNetUserLogins, AspNetRoleClaims, AspNetUserTokens>
    {
      
    }
}
