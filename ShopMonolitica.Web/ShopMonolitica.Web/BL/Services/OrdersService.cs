using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Orders;

namespace ShopMonolitica.Web.BL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersDb OrdersDb;
        private readonly ILogger<OrdersService> logger;

        public OrdersService(IOrdersDb OrdersDb, ILogger<OrdersService> logger)
        {
            this.OrdersDb = OrdersDb;
            this.logger = logger;
        }

        public ServiceResult GetOrder(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = OrdersDb.GetOrder(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo la Orden.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetOrders()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = OrdersDb.GetOrders();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las Ordenes.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveOrders(OrdersRemoveModel ordersRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error removiendo los Datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveOrders(OrdersSaveModel ordersSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (ordersSave is null)
                {
                    result.Success = false;
                    result.Message = "La orden no puede ser nula.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersSave.shipname))
                {
                    result.Success = false;
                    result.Message = "El campo shipname es requerido.";
                    return result;
                }

                if (ordersSave.shipname.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud shipname de la orden debe ser 40 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersSave.shipaddress))
                {
                    result.Success = false;
                    result.Message = "El campo shipaddress es requerido.";
                    return result;
                }

                if (ordersSave.shipaddress.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud shipaddress de la orden debe ser 40 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersSave.shipcity))
                {
                    result.Success = false;
                    result.Message = "El campo shipcity es requerido.";
                    return result;
                }

                if (ordersSave.shipcity.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud shipcity de la orden debe ser 15 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersSave.shipregion))
                {
                    result.Success = false;
                    result.Message = "El campo shipregion es requerido.";
                    return result;
                }

                if (ordersSave.shipregion.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud shipregion de la orden debe ser 15 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersSave.shippostalcode))
                {
                    result.Success = false;
                    result.Message = "El campo shippostalcode es requerido.";
                    return result;
                }

                if (ordersSave.shippostalcode.Length > 10)
                {
                    result.Success = false;
                    result.Message = "La longitud shippostalcode de la orden debe ser 10 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersSave.shipcountry))
                {
                    result.Success = false;
                    result.Message = "El shipcountry es requerido.";
                    return result;
                }

                if (ordersSave.shipcountry.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud shipcountry de la orden debe ser 40 carácteres.";
                    return result;
                }

                this.OrdersDb.SaveOrders(ordersSave);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los Datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateOrders(OrdersUpdateModel ordersUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (ordersUpdate is null)
                {
                    result.Success = false;
                    result.Message = "La orden no puede ser nula.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersUpdate.shipname))
                {
                    result.Success = false;
                    result.Message = "El campo shipname es requerido.";
                    return result;
                }

                if (ordersUpdate.shipname.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud shipname de la orden debe ser 40 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersUpdate.shipaddress))
                {
                    result.Success = false;
                    result.Message = "El campo shipaddress es requerido.";
                    return result;
                }

                if (ordersUpdate.shipaddress.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La longitud shipaddress de la orden debe ser 40 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersUpdate.shipcity))
                {
                    result.Success = false;
                    result.Message = "El campo shipcity es requerido.";
                    return result;
                }

                if (ordersUpdate.shipcity.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud shipcity de la orden debe ser 15 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersUpdate.shipregion))
                {
                    result.Success = false;
                    result.Message = "El campo shipregion es requerido.";
                    return result;
                }

                if (ordersUpdate.shipregion.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud shipregion de la orden debe ser 15 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersUpdate.shippostalcode))
                {
                    result.Success = false;
                    result.Message = "El campo shippostalcode es requerido.";
                    return result;
                }

                if (ordersUpdate.shippostalcode.Length > 10)
                {
                    result.Success = false;
                    result.Message = "La longitud shippostalcode de la orden debe ser 10 carácteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(ordersUpdate.shipcountry))
                {
                    result.Success = false;
                    result.Message = "El shipcountry es requerido.";
                    return result;
                }

                if (ordersUpdate.shipcountry.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud shipcountry de la orden debe ser 40 carácteres.";
                    return result;
                }

                this.OrdersDb.UpdateOrders(ordersUpdate);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando los Datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
