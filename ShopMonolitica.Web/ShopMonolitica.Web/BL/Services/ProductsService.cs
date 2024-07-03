using ShopMonolitica.Web.BL.Core;
using ShopMonolitica.Web.BL.Exceptions;
using ShopMonolitica.Web.BL.Interfaces;
using ShopMonolitica.Web.Data.DbObjects;
using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.interfaces;
using ShopMonolitica.Web.Data.ProductModel;
using ShopMonolitica.Web.Data.ProductModelos;




namespace ShopMonolitica.Web.BL.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProducts productsDb;

        public ProductsService(IProducts products)
        {
            this.productsDb = products;
        }
        public ServiceResult GetProduct(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = productsDb.GetProduct(id);
            }
            catch (Exception ex)
            {
                result.Succes= false;
                result.message= "ocurrio un error obteniendo los productos";

            }
            return result;
        }

        public ServiceResult GetProducts()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = productsDb.GetProducts();
            }
            catch (Exception ex)
            {

                 result.Succes = false;
                result.message = "Ocurrió un error obteniendo los productos";
                
            }
            return result;
        }

        public ServiceResult RemoveProducts(ProductsRemoveModel productsRemoveModel)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (productsRemoveModel == null)
                {
                    result.Succes = false;
                    result.message = "Indicar el campo a eliminar.";
                    return result;
                }
                productsDb.RemoveProducts(productsRemoveModel);
                result.Succes = true;
            } 
            catch (Exception ex)
            {
                result.Succes = false;
                result.message = "Ocurrió un error removiendo los productos";
            }
            return result;
        }

        public ServiceResult SaveProducts(ProductBaseModel products)
        {
            ServiceResult result = new ServiceResult();
            string message = string.Empty;
            try
            {
                
                    if (!IsProductValid(products, ref message))
                        throw new ProductsServiceException(message);
                    this.productsDb.SaveProducts(products);
            }
            catch (Exception ex)
            {
                result.Succes = false;
                result.message = "Ocurrió un error grabando los productos";
            }
            return result;
        }


        public ServiceResult UpdateProducts(ProductBaseModel products)
        {
            ServiceResult result = new ServiceResult();

            string message = string.Empty;
            try
            {
                if (!IsProductValid(products, ref message))
                    throw new ProductsServiceException(message);
                this.productsDb.UpdateProducts(products);
            }
            catch (Exception ex)
            {
                result.Succes = false;
                result.message = "Ocurrió un error actualizando los productos";
            }
            return result;
        }

        private bool IsProductValid(ProductBaseModel products, ref string message)
        {

            bool result = false;

            if (string.IsNullOrEmpty(products.productname))
            {
                message = "El nombre del producto es requerido.";
                return result;
            }

            if (products.productname.Length > 40)
            {
                message = "El nombre del producto no puede ser mayor de 40 caracteres.";
                return result;
            }
            if (products.unitprice == 0)
            {
                message = "El precio no puede ser cero(0).";
                return result;
            }

            else
                result = false;

            return result;
        }

        ServiceResult IProductsService.UpdateProducts(ProductsBaseModel productUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
    