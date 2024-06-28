using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.BL.Exceptions;
using ShopMonolitica.Web.BL.Validator;

namespace ShopMonolitica.Web.BL.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersDb _customersDb;
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ICustomersDb customersDb, ILogger<CustomersService> logger)
        {
            _customersDb = customersDb;
            _logger = logger;
            
        }

        public ServiceResult GetCustomers()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var customers = _customersDb.GetCustomers();
                if (customers == null || !customers.Any())
                {
                    result.Success = false;
                    result.Menssage = "No se encontraron clientes.";
                    return result;
                }
                result.Data = customers;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error obteniendo los datos de los clientes.";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetCustomers(int custid)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var customer = _customersDb.GetCustomers(custid);
                if (customer == null)
                {
                    result.Success = false;
                    result.Menssage = $"No se encontró el cliente con ID {custid}.";
                    return result;
                }
                result.Data = customer;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error obteniendo los datos del cliente.";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }


        public ServiceResult RemoveCustomers(CustomersRemoveModel customersRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (customersRemove is null)
                    throw new CustomersServiceException("No se ha encontrado el cliente");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error eliminando los datos del cliente";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveCustomers(CustomersSaveModel customersSave)
        {
            ServiceResult result = EntityValidator<CustomersSaveModel>.Validate(customersSave, 50);
            if (!result.Success)
            {
                return result; 
            }

            try
            {
                _customersDb.SaveCustomers(customersSave);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error guardando los datos del cliente";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateCustomers(CustomersUpdateModel customersUpdate)
        {
            ServiceResult result = EntityValidator<CustomersUpdateModel>.Validate(customersUpdate, 50);
            if (!result.Success)
            {
                return result; 
            }

            try
            {
                _customersDb.UpdateCustomers(customersUpdate);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Menssage = "Ocurrió un error actualizando los datos del cliente";
                _logger.LogError(result.Menssage, ex.ToString());
            }
            return result;
        }

    }
}
