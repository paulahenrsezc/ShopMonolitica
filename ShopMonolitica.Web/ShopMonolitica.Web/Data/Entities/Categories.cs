using ShopMonolitica.Web.Data.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMonolitica.Web.Data.Entities
{
    [Table("Categories", Schema ="Production")]
    public class Categories : BaseEntity
    {
        [Key]
        public int categoryid { get; set; }
        public string? categoryname { get; set; }
        public string? description { get; set; }

    }
};
