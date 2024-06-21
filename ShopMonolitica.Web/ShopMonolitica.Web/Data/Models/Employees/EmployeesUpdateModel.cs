namespace ShopMonolitica.Web.Data.Models.Employees
{
    public class EmployeesUpdateModel : EmployeesBaseModel
    {
        public DateTime? modify_date { get; set; }
        public int? modify_user { get; set; }
    }
}
