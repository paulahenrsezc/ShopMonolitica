using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.BL.Services;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.interfaces;

namespace ShopMonolitica.Web.BL.Core
{
    public class ServiceIDependency
    {
        public static void ServiceID(IServiceCollection services, IConfiguration configuration)
        {
            //Inyeccion de dependencia - capa de datos -data
            services.AddScoped<ICategoriesDb, CategoriesDb>();
            services.AddScoped<IShippersDb, ShippersDb>();

            //Inyeccion de dependencia - Capa BL

            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IShippersService, ShippersService>();

        }
   

    }
}
