using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppDataUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<House> House { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<House>()
            .HasOne(h => h.Owner)
            .WithMany(u => u.Houses)
            .HasForeignKey(h => h.OwnerId);
        }
    }
}
