using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models
{
    public class ShippersUpdateModel
    {
        public int shipperid { get; set; }

        [Required(ErrorMessage = "Favor completar los campos vacios.")]
        [StringLength(40, ErrorMessage = "No se pueden exceder de 40 caracteres.")]
        public string? companyname { get; set; }

        [Required(ErrorMessage = "Favor completar los campos vacios.")]
        [StringLength(24, ErrorMessage = "No se pueden exceder de 24 caracteres.")]
        public string? phone { get; set; }

    }
}
