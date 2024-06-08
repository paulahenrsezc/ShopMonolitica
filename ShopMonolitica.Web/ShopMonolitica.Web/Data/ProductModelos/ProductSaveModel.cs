using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.ProductModel
{
    public class ProductSaveModel 
    {
        public int productid { get; set; }
        public string? productname { get; set; }

        public double unitprice { get; set; }

        public bool discontinued { get; set; }
        public int? categoryid { get; set; }
        public int? supplierid { get; set; }

    }
}
