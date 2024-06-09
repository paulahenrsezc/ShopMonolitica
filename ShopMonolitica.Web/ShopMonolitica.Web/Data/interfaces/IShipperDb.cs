using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Entities;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IShippersDb
    {
        void SaveShippers(ShippersSaveModel shippers);
        void UpdateShippers(ShippersUpdateModel updateModel);
        void RemoveShippers();


        List<ShippersModel> GetShippers();
        ShippersModel GetShippers(int shipperid);
    }
}
