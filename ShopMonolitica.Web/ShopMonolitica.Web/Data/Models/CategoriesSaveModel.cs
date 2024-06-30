using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models
{
    public class CategoriesSaveModel
    {
        public int categoryid { get; set; }
        [StringLength(15, ErrorMessage = "No se pueden exceder de 15 caracteres.")]
        public string categoryname { get; set; }
        [StringLength(200, ErrorMessage = "No se pueden exceder de 200 caracteres.")]
        public string description { get; set; }
        public DateTime creation_date { get; set; }
        public int creation_user { get; set; }
    }
}
