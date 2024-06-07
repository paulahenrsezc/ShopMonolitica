using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.Extentions
{
    public static class ShipperExtentions
    {
        public static ShipperModel ConvertShipperEntityShipperModel(this Shipper shipper)
    {
           ShipperModel shipperModel = new ShipperModel()
            {
                shipperid = shipper.shipperid,
                companyname = shipper.companyname,
                phone = shipper.phone
            };

            return shipperModel;
     }
    }
}

