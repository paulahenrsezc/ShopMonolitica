using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models
{
    public class CategoriesUpdateModel
    {
        public int categoryid { get; set; }

       [StringLength(15, ErrorMessage = "No se pueden exceder de 15 caracteres.")]
        public string categoryname { get; set; }

        [StringLength(200, ErrorMessage = "No se pueden exceder de 200 caracteres.")]
        public string description { get; set; }
        public DateTime modify_date { get; set; }
        public int? modify_user { get; set; }



    }
}
