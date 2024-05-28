using ShopMonolitica.Web.Data.Core;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class ProductsDb: BaseEntity
    {
        #region
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string ProductType { get; set; }

        = string.Empty;
        public ProductsDb() { }
        #endregion  

    }
}
