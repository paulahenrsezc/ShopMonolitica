using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.Entities;
namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IShipperDb
    {
        void Save(ShipperSaveModel shipper);
        void Update(ShipperUpdateModel updateModel);

        List<ShipperModel> GetShippers();
        ShipperModel GetShipper(int shipperid);
    }
}
