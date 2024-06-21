using ShopMonolitica.Web.Data.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMonolitica.Web.Data.Entities
{
    [Table("Tests", Schema = "Stats")]
    public class Tests
    {
        [Key]
        public string testid { get; set; }
    }
}
