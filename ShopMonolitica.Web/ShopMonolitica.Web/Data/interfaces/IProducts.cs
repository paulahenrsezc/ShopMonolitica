using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.ProductModel;
using ShopMonolitica.Web.Data.ProductModelos;

namespace ShopMonolitica.Web.Data.interfaces
{
    public interface IProducts
    {
        void SaveProducts(ProductSaveModel products);
        void UpdateProducts(ProductUpdateModel products);

        void RemoveProducts(ProductsRemoveModel productsRemove);
     
        List<ProductsModel> GetProducts();
        ProductsModel GetProducts(int productid);
 
       
    }
}
