using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models
{
    public class CustomersRemoveModel : CustomersModel
    {
        [Key]
        public int custid { get; set; }
    }
}
