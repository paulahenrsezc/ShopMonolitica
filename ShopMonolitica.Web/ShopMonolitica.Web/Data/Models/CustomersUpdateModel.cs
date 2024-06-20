using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models
{
    public class CustomersUpdateModel : CustomersModel
    {
        [Key]
        public int custid { get; set; }
    }
}
