using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ShopMonolitica.Web.BL.Exceptions;
using ShopMonolitica.Web.Data.Entities;

namespace ShopMonolitica.Web.Data.Context
{
    public class ShopContext: DbContext
    {
       public ShopContext(DbContextOptions<ShopContext> options): base(options)
        {
        }

        #region"Db Sets"
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        #endregion
    }


}
