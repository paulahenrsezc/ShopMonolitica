using ShopMonolitica.Web.BL.Exceptions;
using ShopMonolitica.Web.Data.Entities;
using Shipper = ShopMonolitica.Web.BL.Exceptions.Shipper;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IShipperDb
    {
        void Add(Shipper shipper);
    }
}
