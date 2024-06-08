using Microsoft.EntityFrameworkCore;
using ShopMonolitica.Web.Data.Entities;

namespace ShopMonolitica.Web.Data.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext>options) : base (options)
        {
            
        }
        #region "DbSet"
        public DbSet<Products> Products { get; set; }

        public DbSet<Suppliers> Suppliers { get; set; }
        #endregion
    }
}
