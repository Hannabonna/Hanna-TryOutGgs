using Microsoft.EntityFrameworkCore;
using TryOut01.Model;

namespace TryOut01
{
    public class dbOnlineContext : DbContext
    {
        public dbOnlineContext(DbContextOptions<dbOnlineContext> options) : base(options){}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

    }

}