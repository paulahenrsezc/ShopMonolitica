using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Models.Employees
{
    public class EmployeesBaseModel
    {
        public int empid { get; set; }

        [StringLength(20, ErrorMessage = "El apellido no puede exceder de 20 caracteres")]
        public string lastname { get; set; }

        [StringLength(10, ErrorMessage = "El nombre no puede exceder de 10 caracteres")]
        public string firstname { get; set; }

        [StringLength(30, ErrorMessage = "El título no puede exceder de 30 caracteres")]
        public string title { get; set; }

        [StringLength(25, ErrorMessage = "El título de cortesía no puede exceder de 25 caracteres")]
        public string titleofcourtesy { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime birthdate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime hiredate { get; set; }

        [StringLength(60, ErrorMessage = "La dirección no puede exceder de 60 caracteres")]
        public string address { get; set; }

        [StringLength(15, ErrorMessage = "La ciudad no puede exceder de 15 caracteres")]
        public string city { get; set; }

        [StringLength(15, ErrorMessage = "La región no puede exceder de 15 caracteres")]
        public string? region { get; set; }

        [StringLength(10, ErrorMessage = "El código postal no puede exceder de 10 caracteres")]
        public string? postalcode { get; set; }

        [StringLength(15, ErrorMessage = "El país no puede exceder de 15 caracteres")]
        public string country { get; set; }

        [StringLength(24, ErrorMessage = "El teléfono no puede exceder de 24 caracteres")]
        public string phone { get; set; }

        public int? mgrid { get; set; }
    }
}
