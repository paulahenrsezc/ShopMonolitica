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
        
        public ShippersModel GetShippers(int shipperid)
        {
            var shippers = _shopContext.Shippers.Find(shipperid);
            return shippers?.ConvertShipEntityShippersModel();
        }
    }
};