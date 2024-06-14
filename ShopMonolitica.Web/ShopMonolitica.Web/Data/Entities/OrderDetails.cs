using ShopMonolitica.Web.Data.Core;

namespace ShopMonolitica.Web.Data.Entities
{
    public class OrderDetails
    {
        public int? orderid { get; set; }
        public int? productid { get; set; }
        public decimal unitPrice { get; set; }
        public short qty { get; set; }
        public decimal discount { get; set; }
    }
}
