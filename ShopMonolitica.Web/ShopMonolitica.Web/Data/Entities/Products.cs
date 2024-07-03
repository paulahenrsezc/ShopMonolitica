using ShopMonolitica.Web.Data.Core;
using ShopMonolitica.Web.Data.ProductModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMonolitica.Web.Data.Entities
{
    public class ProductsBaseModel: BaseEntity
    {
        [Key]
        public int productid { get; set; }
        public int supplierid { get; set; }
        public int? categoryid { get; set; }
        public string? productname { get; set; }

        public double unitprice { get; set; }

        public bool discontinued { get; set; }
    }
}
