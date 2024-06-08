using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.ProductModel;

namespace ShopMonolitica.Web.Data.Models
{
    public class ProductsModel
    {
       
        public int productid { get; set; }
        public string? productname { get; set; }

        public double unitprice { get; set;}

        public bool discontinued { get; set;}
        public int? categoryid { get; set;}
        public int? supplierid { get; set;}


    }
}
