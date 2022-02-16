using DataAccess.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=TestOnlineStore;User ID=sa;Password=pa55w0rd!;");

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Outlet> Outlets { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Rent> Rents { get; set; }
    }
}
