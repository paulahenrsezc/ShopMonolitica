using ShopMonolitica.Web.Data.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMonolitica.Web.Data.Entities
{
    [Table("Scores", Schema = "Stats")]
    public class Scores
    {
        public string testid { get; set; }
        [Key]
        public string studentid { get; set; }
        public byte score { get; set; }
    }
}
