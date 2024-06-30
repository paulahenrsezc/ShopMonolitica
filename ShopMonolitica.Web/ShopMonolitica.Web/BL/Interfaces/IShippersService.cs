using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface IShippersService
    {
        ServiceResult SaveShippers(ShippersSaveModel shippers);
        ServiceResult UpdateShippers(ShippersUpdateModel updateModel);
        ServiceResult GetShippers();
        ServiceResult GetShippersModel(int shipperid);
    }
}
