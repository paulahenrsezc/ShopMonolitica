using Microsoft.EntityFrameworkCore;
using ShopMonolitica.Web.Data.Entities;

namespace ShopMonolitica.Web.Data.Context
{
    public class ShopContext : DbContext
    {
        #region"Constructor"
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        #endregion

        #region"Db set"'
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Tests> Tests { get; set; }
        #endregion
    }
}
