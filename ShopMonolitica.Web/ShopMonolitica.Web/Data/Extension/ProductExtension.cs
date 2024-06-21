using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
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
  
            };
        }  
        public static Products ConvertProductSaveModel(this ProductSaveModel productsave)
        {
            return new Products()
            {
                productname = productsave.productname,  
                creation_user = productsave.creation_user,
                creation_date = productsave.creation_date,
                unitprice = productsave.unitprice, 

            };
        }

        public static ProductsModel ConvertProductUpdateModel(this Products productupdate)
        {
           return new ProductsModel   
            {
                productname = productupdate.productname,
                unitprice = productupdate.unitprice,
                discontinued = productupdate.discontinued,

            };
        }

        //public static void UpdateFromModel(this Products products, ProductUpdateModel model)

        //{
                
        //    model.productname = model.productname;
        //    model.unitprice = model.unitprice;
        //    model.discontinued = model.discontinued;
        //    model.categoryid = model.categoryid;
        //    model.supplierid = model.supplierid;
        //}


    }
}
