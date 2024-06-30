using ShopMonolitica.Web.Data.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMonolitica.Web.Data.Entities
{
    [Table("Shippers", Schema ="Sales")]
    public class Shippers
    {
        [Key]
        public int shipperid { get; set; }
        public string? companyname { get; set; }
        public string? phone { get; set; }

    }
};
