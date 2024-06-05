namespace ShopMonolitica.Web.Data.Models.Employees
{
    public class EmployeesUpdateModel : EmployeesModel
    {
        public DateTime? modify_date { get; set; }
        public int? modify_user { get; set; }
    }
}
