using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models.OrderDetails
{
    public class OrderDetailsSaveModel : OrderDetailsBaseModel
    {
        [Key]
        public int orderid { get; set; }
        public int productid { get; set; }
    }
}
