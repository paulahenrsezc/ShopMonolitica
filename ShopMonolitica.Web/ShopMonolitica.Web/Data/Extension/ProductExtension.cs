using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.ProductModel;
namespace ShopMonolitica.Web.Data.Extension
{
    public static class ProductExtension
    {
        public static ProductsModel ConvertProductEntitieModel(this Products products)
        {
            return new ProductsModel()
            {
                productid = products.productid,
                productname = products.productname,
                unitprice = products.unitprice,
                discontinued = products.discontinued,
                categoryid = products.categoryid,
                supplierid = products.supplierid,
            };
        }  
        public static ProductSaveModel ConvertProductSaveModel(this ProductSaveModel productsave)
        {
            return new ProductSaveModel()
            {
                productid = productsave.productid,
                productname = productsave.productname,
                unitprice = productsave.unitprice,
                discontinued = productsave.discontinued,
                categoryid = productsave.categoryid,
                supplierid = productsave.supplierid,
            };
        }
    }
}
