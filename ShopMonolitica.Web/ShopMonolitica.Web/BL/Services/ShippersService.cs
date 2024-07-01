using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Exceptions;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using static ShopMonolitica.Web.Data.Entities.EntityValidatorCategories;

namespace ShopMonolitica.Web.BL.Services
{
    public class ShippersService : IShippersService
    {
        private readonly IShippersDb shippersDb;
        private readonly ILogger<ShippersService> logger;

        public ShippersService(IShippersDb shippersDb, ILogger<ShippersService> logger)
        {
            this.shippersDb = shippersDb ?? throw new ShippersDbException(nameof(shippersDb));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ServiceResult GetShippers()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = shippersDb.GetShippers();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las Shippers.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetShippersModel(int shipperid)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = shippersDb.GetShippersModel(shipperid);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las shippers.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult SaveShippers(ShippersSaveModel shippers)
        {
            ServiceResult result = EntityValidator<ShippersSaveModel>.Validate(shippers);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                shippersDb.SaveShippers(shippers);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la shipper.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult UpdateShippers(ShippersUpdateModel updateModel)
        {
            ServiceResult result = EntityValidator<ShippersUpdateModel>.Validate(updateModel);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                shippersDb.UpdateShippers(updateModel);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando la shipper.";
                logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
