using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.BL.Core;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IShippersDb
    {
        void SaveShippers(ShippersSaveModel shippers);
        void UpdateShippers(ShippersUpdateModel updateModel);
        void RemoveShippers(ShippersRemoveModel removeModel);
        List<ShippersModel> GetShippers();
        ShippersModel GetShippersModel(int shipperid);
    }
}
