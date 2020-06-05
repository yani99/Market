using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Market.DAL.Models
{
    public partial class MarketDBContext : IdentityDbContext<AspNetUsers, AspNetRoles, string, AspNetUserClaims,
        AspNetUserRoles, AspNetUserLogins, AspNetRoleClaims, AspNetUserTokens>
    {    
    }
}
