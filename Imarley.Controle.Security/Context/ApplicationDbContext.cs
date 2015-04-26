using System.Data.Entity;
using Imarley.Controle.Security.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Imarley.Controle.Security.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Context", throwIfV1Schema: false)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Claims> Claims { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}
