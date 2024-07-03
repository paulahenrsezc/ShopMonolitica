using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.ProductModel;
using ShopMonolitica.Web.Data.ProductModelos;

namespace ShopMonolitica.Web.BL.Interfaces
{
    public interface IProductsService
    {
        ServiceResult GetProducts();
        ServiceResult GetProduct(int id);
        ServiceResult UpdateProducts(ProductsBaseModel productUpdateModel);
        ServiceResult RemoveProducts(ProductsRemoveModel productsRemoveModel);
        ServiceResult SaveProducts(ProductBaseModel products);
       
    }
}
