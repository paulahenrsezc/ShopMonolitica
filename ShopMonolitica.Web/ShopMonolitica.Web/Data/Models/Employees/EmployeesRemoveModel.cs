namespace ShopMonolitica.Web.Data.Models.Employees
{
    public class EmployeesRemoveModel : EmployeesModel
    {
        public int? delete_user { get; set; }
        public DateTime? delete_date { get; set; }
        public bool deleted { get; set; }
    }
}
