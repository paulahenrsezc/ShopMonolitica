using Microsoft.Extensions.Logging;
using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Employees;
using ShopMonolitica.Web.Data.Models.OrderDetails;
using static ShopMonolitica.Web.Data.Entities.Entity;

namespace ShopMonolitica.Web.BL.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesDb employeesDb;
        private readonly ILoggerDb<EmployeesService> _logger;

        public EmployeesService (IEmployeesDb employeesDb, ILoggerDb<EmployeesService> logger)
        {
            this.employeesDb = employeesDb;
            _logger = logger;

        }

        public ServiceResult GetEmployees()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = employeesDb.GetEmployees();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los empleados";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetEmployees(int id)
        {
            var result = new ServiceResult();

            try
            {
                result.Data = employeesDb.GetEmployees(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los empleados";
                _logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveEmployees(EmployeesRemoveModel employeesRemove)
        {
            var result = new ServiceResult();

            try
            {
                if (employeesRemove == null)
                {
                    result.Success = false;
                    result.Message = "El empleado no puede ser nulo.";
                    return result;
                }
                this.employeesDb.RemoveEmployees(employeesRemove);
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

        public ServiceResult SaveEmployees(EmployeesSaveModel employeesSave)
        {
            var result = EntityValidator<EmployeesSaveModel>.Validate(employeesSave);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                employeesDb.SaveEmployees(employeesSave);
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

        public ServiceResult UpdateEmployees(EmployeesUpdateModel employeesUpdate)
        {
            var result = EntityValidator<EmployeesUpdateModel>.Validate(employeesUpdate);
            if (!result.Success)
            {
                return result;
            }
            try
            {
                employeesDb.UpdateEmployees(employeesUpdate);
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
