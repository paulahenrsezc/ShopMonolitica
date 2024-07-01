using Microsoft.Extensions.Logging;
using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models.Employees;

namespace ShopMonolitica.Web.BL.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesDb employeesDb;
        private readonly ILogger<EmployeesService> logger;

        public EmployeesService (IEmployeesDb employeesDb, ILogger<EmployeesService> logger)
        {
            this.employeesDb = employeesDb;
            this.logger = logger;
        }

        public ServiceResult GetEmployees()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = employeesDb.GetEmployees();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los empleados";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult GetEmployees(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.employeesDb.GetEmployees(id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los empleados";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveEmployees(EmployeesRemoveModel employeesRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (employeesRemove is null)
                {
                    result.Success = false;
                    result.Message = "El empleado no puede ser nulo.";
                    return result;
                }
                this.employeesDb.RemoveEmployees(employeesRemove);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error removiendo los datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveEmployees(EmployeesSaveModel employeesSave)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (employeesSave is null)
                {
                    result.Success = false;
                    result.Message = "El empleado no puede ser nulo.";
                    return result;
                }

                if (employeesSave.empid <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del empleado debe ser un número entero positivo.";
                    return result;
                }
                if (string.IsNullOrEmpty(employeesSave.lastname))
                {
                    result.Success = false;
                    result.Message = "El apellido del empleado es requerido.";
                    return result;
                }
                if (employeesSave.lastname.Length > 20)
                {
                    result.Success = false;
                    result.Message = "La longitud del apellido del empleado debe ser de 20 cáracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(employeesSave.firstname))
                {
                    result.Success = false;
                    result.Message = "El nombre del empleado es requerido.";
                    return result;
                }
                if (employeesSave.firstname.Length > 10)
                {
                    result.Success = false;
                    result.Message = "La longitud del nombre del empleado debe ser de 10 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesSave.title))
                {
                    result.Success = false;
                    result.Message = "El título del empleado es requerido.";
                    return result;
                }
                if (employeesSave.title.Length > 30)
                {
                    result.Success = false;
                    result.Message = "La longitud del título del empleado debe ser de 30 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesSave.titleofcourtesy))
                {
                    result.Success = false;
                    result.Message = "El título de cortesía del empleado es requerido.";
                    return result;
                }
                if (employeesSave.titleofcourtesy.Length > 25)
                {
                    result.Success = false;
                    result.Message = "La longitud del título de cortesía del empleado debe ser de 25 cáracteres.";
                    return result;
                }

                if (employeesSave.birthdate == default(DateTime))
                {
                    result.Success = false;
                    result.Message = "La fecha de nacimiento del empleado es requerida.";
                    return result;
                }

                if (employeesSave.hiredate == default(DateTime))
                {
                    result.Success = false;
                    result.Message = "La fecha de contratación del empleado es requerida.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesSave.address))
                {
                    result.Success = false;
                    result.Message = "La dirección del empleado es requerida.";
                    return result;
                }
                if (employeesSave.address.Length > 60)
                {
                    result.Success = false;
                    result.Message = "La longitud de la dirección del empleado debe ser de 60 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesSave.city))
                {
                    result.Success = false;
                    result.Message = "La ciudad del empleado es requerida.";
                    return result;
                }
                if (employeesSave.city.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud de la ciudad del empleado debe ser de 15 cáracteres.";
                    return result;
                }

                if (!string.IsNullOrEmpty(employeesSave.region) && employeesSave.region.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud de la región del empleado debe ser de 15 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesSave.postalcode))
                {
                    result.Success = false;
                    result.Message = "El código postal del empleado es requerido.";
                    return result;
                }
                if (employeesSave.postalcode.Length > 10)
                {
                    result.Success = false;
                    result.Message = "La longitud del código postal del empleado debe ser de 10 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesSave.country))
                {
                    result.Success = false;
                    result.Message = "El país del empleado es requerido.";
                    return result;
                }
                if (employeesSave.country.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud del país del empleado debe ser de 15 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesSave.phone))
                {
                    result.Success = false;
                    result.Message = "El teléfono del empleado es requerido.";
                    return result;
                }
                if (employeesSave.phone.Length > 24)
                {
                    result.Success = false;
                    result.Message = "La longitud del teléfono del empleado debe ser de 24 cáracteres.";
                    return result;
                }

                if (employeesSave.mgrid <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del manager debe ser un número entero positivo.";
                    return result;
                }
                this.employeesDb.SaveEmployees(employeesSave);

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error grabando los datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateEmployees(EmployeesUpdateModel employeesUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                
                if (employeesUpdate is null)
                {
                    result.Success=false;
                    result.Message = "El empleado no puede ser nulo.";
                    return result;
                }

                if (employeesUpdate.empid <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del empleado debe ser un número entero positivo.";
                    return result;
                }
                if (string.IsNullOrEmpty(employeesUpdate.lastname))
                {
                    result.Success = false;
                    result.Message = "El apellido del empleado es requerido.";
                    return result;
                }
                if (employeesUpdate.lastname.Length > 20)
                {
                    result.Success = false;
                    result.Message = "La longitud del apellido del empleado debe ser de 20 cáracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(employeesUpdate.firstname))
                {
                    result.Success = false;
                    result.Message = "El nombre del empleado es requerido.";
                    return result;
                }
                if (employeesUpdate.firstname.Length > 10)
                {
                    result.Success = false;
                    result.Message = "La longitud del nombre del empleado debe ser de 10 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesUpdate.title))
                {
                    result.Success = false;
                    result.Message = "El título del empleado es requerido.";
                    return result;
                }
                if (employeesUpdate.title.Length > 30)
                {
                    result.Success = false;
                    result.Message = "La longitud del título del empleado debe ser de 30 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesUpdate.titleofcourtesy))
                {
                    result.Success = false;
                    result.Message = "El título de cortesía del empleado es requerido.";
                    return result;
                }
                if (employeesUpdate.titleofcourtesy.Length > 25)
                {
                    result.Success = false;
                    result.Message = "La longitud del título de cortesía del empleado debe ser de 25 cáracteres.";
                    return result;
                }

                if (employeesUpdate.birthdate == default(DateTime))
                {
                    result.Success = false;
                    result.Message = "La fecha de nacimiento del empleado es requerida.";
                    return result;
                }

                if (employeesUpdate.hiredate == default(DateTime))
                {
                    result.Success = false;
                    result.Message = "La fecha de contratación del empleado es requerida.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesUpdate.address))
                {
                    result.Success = false;
                    result.Message = "La dirección del empleado es requerida.";
                    return result;
                }
                if (employeesUpdate.address.Length > 60)
                {
                    result.Success = false;
                    result.Message = "La longitud de la dirección del empleado debe ser de 60 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesUpdate.city))
                {
                    result.Success = false;
                    result.Message = "La ciudad del empleado es requerida.";
                    return result;
                }
                if (employeesUpdate.city.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud de la ciudad del empleado debe ser de 15 cáracteres.";
                    return result;
                }

                if (!string.IsNullOrEmpty(employeesUpdate.region) && employeesUpdate.region.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud de la región del empleado debe ser de 15 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesUpdate.postalcode))
                {
                    result.Success = false;
                    result.Message = "El código postal del empleado es requerido.";
                    return result;
                }
                if (employeesUpdate.postalcode.Length > 10)
                {
                    result.Success = false;
                    result.Message = "La longitud del código postal del empleado debe ser de 10 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesUpdate.country))
                {
                    result.Success = false;
                    result.Message = "El país del empleado es requerido.";
                    return result;
                }
                if (employeesUpdate.country.Length > 15)
                {
                    result.Success = false;
                    result.Message = "La longitud del país del empleado debe ser de 15 cáracteres.";
                    return result;
                }

                if (string.IsNullOrEmpty(employeesUpdate.phone))
                {
                    result.Success = false;
                    result.Message = "El teléfono del empleado es requerido.";
                    return result;
                }
                if (employeesUpdate.phone.Length > 24)
                {
                    result.Success = false;
                    result.Message = "La longitud del teléfono del empleado debe ser de 24 cáracteres.";
                    return result;
                }

                if (employeesUpdate.mgrid <= 0)
                {
                    result.Success = false;
                    result.Message = "El ID del manager debe ser un número entero positivo.";
                    return result;
                }
                this.employeesDb.UpdateEmployees(employeesUpdate);

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
