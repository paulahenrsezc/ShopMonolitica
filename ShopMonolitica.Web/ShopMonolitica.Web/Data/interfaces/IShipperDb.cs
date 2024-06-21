using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Entities;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IShippersDb
    {
        List<ShippersModel> GetShippers();
        ShippersModel GetShippers(int shipperid);
    }
}
