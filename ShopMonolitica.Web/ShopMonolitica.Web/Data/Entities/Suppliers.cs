using ShopMonolitica.Web.Data.Core;
using System.ComponentModel.DataAnnotations;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Suppliers:BaseEntity
    {
       
        public int SupplierId { get; set; }

 
        public string? CompanyName { get; set; }

       
        public string? ContactName { get; set; }

      
        public string? ContactTitle { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }
        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

        public DateTime CreationDate { get; set; }

        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? ModifyUser { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int? DeleteUser { get; set; }

        public bool Deleted { get; set; }
    }

}

