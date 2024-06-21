using ShopMonolitica.Web.Data.Core;
using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Suppliers : PersonBase
    {
        [Key]
        public int supplierid { get; set; }


    }

}
