using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataBaseContext : IdentityDbContext<Client, IdentityRole<int>, int>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=TestOnlineStore;User ID=sa;Password=pa55w0rd!;");
            base.OnModelCreating(builder);
            this.SeedRoles(builder);
        }

        public DbSet<Outlet> Outlets { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Rent> Rents { get; set; }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Manager", ConcurrencyStamp = "1", NormalizedName = "MANAGER" },
                new IdentityRole<int>() { Id = 2, Name = "Client", ConcurrencyStamp = "2", NormalizedName = "CLIENT" }
            );
        }
    }
}
