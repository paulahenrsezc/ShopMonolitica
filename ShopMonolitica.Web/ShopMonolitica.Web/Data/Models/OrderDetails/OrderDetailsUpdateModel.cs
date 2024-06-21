namespace ShopMonolitica.Web.Data.Models.OrderDetails
{
    public class OrderDetailsUpdateModel : OrderDetailsBaseModel
    {
        public DateTime? modify_date { get; set; }
        public int? modify_user { get; set; }
    }
}
