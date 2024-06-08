using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.ProductModel;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IProducts
    {
        void SaveProducts(ProductSaveModel products);
        void UpdateProducts(ProductUpdateModel products);
     
        List<ProductsModel> GetProducts();
        ProductsModel GetProducts(int productid);
 
       
    }
}
