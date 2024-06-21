using ShopMonolitica.Web.Data.Core;
using ShopMonolitica.Web.Data.ProductModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Products: BaseEntity
    {
        [Key]
        public int productid { get; set; }
        public int supplierid { get; set; }
        // Añadir esta línea
        public int? categoryid { get; set; }
        public string? productname { get; set; }

        public double unitprice { get; set; }

        public bool discontinued { get; set; }
    }
}
