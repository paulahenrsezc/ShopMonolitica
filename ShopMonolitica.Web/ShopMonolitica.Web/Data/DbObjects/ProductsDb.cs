using ShopMonolitica.Web.Data.Context;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.Models;
using ShopMonolitica.Web.Data.ProductModel;
using ShopMonolitica.Web.Data.Extension;
using ShopMonolitica.Web.Data.ProductModelos;


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


        public void RemoveProducts(ProductsRemoveModel productsRemove)
        {
            Products productToDelete = this._context.Products.Find(productsRemove.productid);

            productToDelete.deleted = productsRemove.deleted;
            productToDelete.delete_date = productsRemove.delete_date;
            productToDelete.delete_user = productsRemove.delete_user;

            this._context.Products.Update(productToDelete);
        }


        public void SaveProducts(ProductSaveModel productsave)
        {
            Products saveEntity = productsave.ConvertProductSaveModel();

            _context.Products.Add(saveEntity);
            _context.SaveChanges();     
            
        }

        public void UpdateProducts(ProductUpdateModel products)
        {
            Products productsToUpdate = _context.Products.Find(products.productid);

            if (productsToUpdate != null)
            
                productsToUpdate.ConvertProductUpdateModel();
                _context.Products.Update(productsToUpdate);
                _context.SaveChanges();
            
        }
    }

        
}