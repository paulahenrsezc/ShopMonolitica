namespace ShopMonolitica.Web.Data.Models.OrderDetails
{
    public class OrderDetailsUpdateModel : OrderDetailsModel
    {
        public int orderid { get; set; }
        public int? productid { get; set; }

    }
}
