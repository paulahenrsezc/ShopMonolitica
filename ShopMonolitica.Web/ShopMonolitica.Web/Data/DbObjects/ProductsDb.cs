using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.ProductModel;
using ShopMonolitica.Web.Data.Extension;


namespace ShopMonolitica.Web.Data.DbObjects
{
    public class ProductsDb : IProducts
    {
        private readonly ShopContext _context;

        public ProductsDb(ShopContext context)
        {
            _context = context;
        }

        public List<ProductsModel> GetProducts()
        {
            return _context.Products.Select(products => products.ConvertProductEntitieModel()
            ).ToList();
        }

        public ProductsModel GetProducts(int productid)
        {
            var products = _context.Products.Find(productid).ConvertProductEntitieModel();

            return products;
            
            
        }

        public void RemoveProducts()
        {
            throw new NotImplementedException();
        }
        
        public void SaveProducts(ProductSaveModel productsave)
        {
            ProductSaveModel saveEntity = productsave.ConvertProductSaveModel();
            //ShopContext.Products.Add(saveEntity);
           _context.SaveChanges();
            
            
            
        }

        public void UpdateProducts(ProductUpdateModel products)
        {
            throw new NotImplementedException();
        }
    }
}