using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShopMonolitica.Web.BL.Exceptions;

namespace ShopMonolitica.Web.Data.Context
{
    public class ShopContext: DbContext
    {
       public ShopContext(DbContextOptions<ShopContext> options): base(options)
        {
        }

        #region"Db Sets"
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        #endregion
    }


}
