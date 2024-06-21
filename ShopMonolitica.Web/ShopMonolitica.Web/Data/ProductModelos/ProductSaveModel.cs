using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.ProductModel;
using ShopMonolitica.Web.Data.ProductModelos;


namespace ShopMonolitica.Web.Data.ProductModel
{
    public class ProductSaveModel : ProductBaseModel   
    {
        public int supplierid { get; set; } // Añadir esta línea

        public int? categoryid { get; set; }

    }
}
