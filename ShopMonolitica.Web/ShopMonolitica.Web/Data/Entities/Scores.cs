using ShopMonolitica.Web.Data.Core;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Scores : BaseEntity
    {
        public int testid { get; set; }
        public int studentid { get; set; }
        public int score { get; set; }
    }
}
