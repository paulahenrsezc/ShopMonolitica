using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models.Orders
{
    public class OrdersUpdateModel : OrdersBaseModel
    {
        public int orderid { get; set; }
    }
}
