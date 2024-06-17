using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models
{
    public class CustomersSaveModel : CustomersModel
    {
        [Key]
        public int custid { get; set; }
    }
}
