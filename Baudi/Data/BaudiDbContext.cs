namespace Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BaudiDbContext : IdentityDbContext<User>
    {
        public BaudiDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BaudiDbContext Create()
        {
            return new BaudiDbContext();
        }
    }
}
