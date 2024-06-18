using Microsoft.EntityFrameworkCore;
using ShopMonolitica.Web.Data.Entities;

namespace ShopMonolitica.Web.Data.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        #region "Db Sets"
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .ToTable("Customers", "Sales");
            modelBuilder.Entity<Users>()
                .ToTable("Users", "Security");

        }

    }

}
