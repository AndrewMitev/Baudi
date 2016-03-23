namespace Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class BaudiDbContext : IdentityDbContext<User>, IBaudiDbContext
    {
        public BaudiDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BaudiDbContext Create()
        {
            return new BaudiDbContext();
        }

        public IDbSet<Car> Cars { get; set; }
    }
}
