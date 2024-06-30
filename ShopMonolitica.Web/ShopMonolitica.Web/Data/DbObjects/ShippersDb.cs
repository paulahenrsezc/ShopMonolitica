using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Extensions;
using ShopMonolitica.Web.Data.Extentions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.DbObjects
{


    public class ShippersDb : IShippersDb
    {
        private readonly ShopContext _shopContext;

        public ShippersDb(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ShippersModel> GetShippers()
        {
            return _shopContext.Shippers
                 .Select(shippers => shippers
                 .ConvertShipEntityToShippersModel()).ToList();
        }

   
        public ShippersModel GetShippersModel(int shipperid)
        {
            var shippers = _shopContext.Shippers.Find(shipperid);
            return shippers.ConvertShipEntityShippersModel();
        }

        public void SaveShippers(ShippersSaveModel shippers)
        {
            Shippers shippersEntity = shippers.ConvertShipSaveModelToShipperEntity();
            _shopContext.Shippers.Add(shippersEntity);
            _shopContext.SaveChanges();
        }

        public void UpdateShippers(ShippersUpdateModel updateModel)
        {
            Shippers shippersToUpdate = _shopContext.Shippers.Find(updateModel.shipperid);
            if (shippersToUpdate != null)
            {
                shippersToUpdate.UpdateFromModel(updateModel);
                _shopContext.Shippers.Update(shippersToUpdate);
                _shopContext.SaveChanges();
            }
        }
    }
};