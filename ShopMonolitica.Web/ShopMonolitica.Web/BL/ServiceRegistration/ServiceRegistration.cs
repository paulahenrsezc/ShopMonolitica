using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.BL.Services;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.interfaces;

namespace ShopMonolitica.Web.BL.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Agregar la dependencia de datos//
            services.AddScoped<ICustomersDb, CustomersDb>();
            services.AddScoped<IUsersDb, UsersDb>();


            //Agregar la dependencia BL//
            services.AddTransient<ICustomersService, CustomersService>();
            services.AddTransient<IUsersService, UsersService>();

        }
    }
}
