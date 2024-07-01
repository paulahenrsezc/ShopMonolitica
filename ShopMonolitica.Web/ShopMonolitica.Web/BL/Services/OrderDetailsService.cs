using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.OrderDetails;
using static ShopMonolitica.Web.Data.Entities.Entity;

namespace ShopMonolitica.Web.BL.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsDb orderdetailsDb;
        private readonly ILoggerDb<EmployeesService> _logger;
        public OrderDetailsService(IOrderDetailsDb orderdetailsDb, ILoggerDb<EmployeesService> logger)
        {
            this.orderdetailsDb = orderdetailsDb;
            _logger = logger;
        }

        public ServiceResult GetOrderDetails()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = orderdetailsDb.GetOrderDetails();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los detalles de las ordenes";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetOrderDetails(int id)
        {
            var result = new ServiceResult();

            try
            {
                result.Data = orderdetailsDb.GetOrderDetails(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los detalles de las ordenes";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveOrderDetails(OrderDetailsRemoveModel orderDetailsRemove)
        {
            var result = new ServiceResult();

            try
            {
                if (orderDetailsRemove == null)
                {
                    result.Success = false;
                    result.Message = "Los detalles de las ordenes no pueden ser nulo.";
                    return result;
                }
                this.orderdetailsDb.RemoveOrderDetails(orderDetailsRemove);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error removiendo los datos.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveOrderDetails(OrderDetailsSaveModel orderDetailsSave)
        {
            var result = EntityValidator<OrderDetailsSaveModel>.Validate(orderDetailsSave);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                orderdetailsDb.SaveOrderDetails(orderDetailsSave);
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error grabando los datos.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateOrderDetails(OrderDetailsUpdateModel orderDetailsUpdate)
        {
            var result = EntityValidator<OrderDetailsUpdateModel>.Validate(orderDetailsUpdate);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                orderdetailsDb.UpdateOrderDetails(orderDetailsUpdate);
                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando los datos.";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

    }
}
