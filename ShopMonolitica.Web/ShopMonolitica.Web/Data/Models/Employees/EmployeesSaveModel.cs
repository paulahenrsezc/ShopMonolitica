using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models.Employees
{
    public class EmployeesSaveModel : EmployeesBaseModel
    {
        [Key]
        public int empid { get; set; }
    }
}
