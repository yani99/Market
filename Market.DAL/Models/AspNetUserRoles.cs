namespace Market.Models
{
    public partial class AspNetUserRoles
    {
        public virtual AspNetRoles Role { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
