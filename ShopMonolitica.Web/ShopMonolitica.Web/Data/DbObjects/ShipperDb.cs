using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Extentions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class ShipperDb : IShipperDb
    {
        private readonly ShopContext _shopContext;

        public ShipperDb(ShopContext shopContext)
        {
            this._shopContext = shopContext;
        }
        public ShipperModel GetShipper(int shipperid)
        {
            var shipper = _shopContext.Shippers.Find(shipperid).ConvertShipperEntityShipperModel();
            return shipper;
        }

        public List<ShipperModel> GetShippers()
        {
            throw new NotImplementedException();
        }

        public void Save(ShipperSaveModel shipper)
        {
            throw new NotImplementedException();
        }

        public void Update(ShipperUpdateModel updateModel)
        {
            throw new NotImplementedException();
        }
    }
}
