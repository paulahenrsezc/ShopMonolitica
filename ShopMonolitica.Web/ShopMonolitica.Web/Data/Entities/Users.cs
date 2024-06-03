using ShopMonolitica.Web.Data.Core;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Users : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}
