using ShopMonolitica.Web.Data.Core;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Shippers : BaseEntity
    {
        public int shipperid { get; set; }
        public string? companyname { get; set; }
        public string? phone { get; set; }

    }
};
