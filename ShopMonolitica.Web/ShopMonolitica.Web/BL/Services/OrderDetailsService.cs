using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.OrderDetails;

namespace ShopMonolitica.Web.BL.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IOrderDetailsDb orderdetailsDb;
        private readonly ILogger<EmployeesService> logger;
        public OrderDetailsService(IOrderDetailsDb orderdetailsDb, ILogger<EmployeesService> logger)
        {
            this.orderdetailsDb = orderdetailsDb;
            this.logger = logger;
        }

        public ServiceResult GetOrderDetails()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = orderdetailsDb.GetOrderDetails();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los detalles de las ordenes";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetOrderDetails(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.orderdetailsDb.GetOrderDetails(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los detalles de las ordenes";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveOrderDetails(OrderDetailsRemoveModel orderDetailsRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (orderDetailsRemove is null)
                {
                    result.Success = false;
                    result.Message = "El empleado no puede ser nulo.";
                    return result;
                }
                this.orderdetailsDb.RemoveOrderDetails(orderDetailsRemove);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error removiendo los datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveOrderDetails(OrderDetailsSaveModel orderDetailsSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (orderDetailsSave is null)
                {
                    result.Success = false;
                    result.Message = "Los detalles de las ordenes no pueden ser nulo.";
                    return result;
                }

                if (orderDetailsSave.orderid <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID de la orden debe ser un número entero positivo.";
                    return result;
                }

                if (orderDetailsSave.productid <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del producto debe ser un número entero positivo.";
                    return result;
                }

                if (orderDetailsSave.unitprice <= 0)
                {
                    result.Success = false;
                    result.Message = "El precio unitario debe ser un valor positivo.";
                    return result;
                }

                if (orderDetailsSave.qty <= 0)
                {
                    result.Success = false;
                    result.Message = "La cantidad debe ser un valor positivo.";
                    return result;
                }

                if (orderDetailsSave.discount < 0 || orderDetailsSave.discount >= 10)
                {
                    result.Success = false;
                    result.Message = "El descuento debe ser un valor entre 0.000 y 9.999.";
                    return result;
                }
                this.orderdetailsDb.SaveOrderDetails(orderDetailsSave);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error grabando los datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateOrderDetails(OrderDetailsUpdateModel orderDetailsUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (orderDetailsUpdate is null)
                {
                    result.Success = false;
                    result.Message = "Los detalles de las ordenes no pueden ser nulo.";
                    return result;
                }

                if (orderDetailsUpdate.orderid <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID de la orden debe ser un número entero positivo.";
                    return result;
                }

                if (orderDetailsUpdate.productid <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del producto debe ser un número entero positivo.";
                    return result;
                }

                if (orderDetailsUpdate.unitprice <= 0)
                {
                    result.Success = false;
                    result.Message = "El precio unitario debe ser un valor positivo.";
                    return result;
                }

                if (orderDetailsUpdate.qty <= 0)
                {
                    result.Success = false;
                    result.Message = "La cantidad debe ser un valor positivo.";
                    return result;
                }

                if (orderDetailsUpdate.discount < 0 || orderDetailsUpdate.discount >= 10)
                {
                    result.Success = false;
                    result.Message = "El descuento debe ser un valor entre 0.000 y 9.999.";
                    return result;
                }
                this.orderdetailsDb.UpdateOrderDetails(orderDetailsUpdate);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando los datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

    }
}
