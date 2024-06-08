using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using System.Runtime.Intrinsics.Arm;
using ShopMonolitica.Web.Data.Extentions;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class ShippersDb : IShipperDb
    {
        private readonly ShopContext _shopContext;

        public ShippersDb( ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public ShipperModel GetShippers(int shipperid)
        {
            var shippers = _shopContext.Shippers.Find(shipperid).ConvertShipEntityToShippersModel();
            return shippers;
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
