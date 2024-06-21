using ShopMonolitica.Web.Data.Models;

namespace ShopMonolitica.Web.Data.ProductModelos
{
    public class ProductBaseModel : ProductsModel
    {
        public int creation_user { get; set; }

        public DateTime creation_date { get; set; }
    }
}
