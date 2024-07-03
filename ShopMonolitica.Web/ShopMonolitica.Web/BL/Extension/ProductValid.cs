using ShopMonolitica.Web.Data.Entities;
using ShopMonolitica.Web.Data.ProductModel;

namespace ShopMonolitica.Web.BL.Extension
{
    public class ProductValid
    {
        public bool IsProductValid(ProductSaveModel products, ref string message)
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
    }
}
