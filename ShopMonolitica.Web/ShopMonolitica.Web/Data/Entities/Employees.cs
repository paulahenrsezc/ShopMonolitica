using ShopMonolitica.Web.Data.Core;

namespace ShopMonolitica.Web.Data.Entities
{
    public class Employees:BaseEntity
    {
        public int empid { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string title { get; set; }
        public string titleofcourtesy { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime hiredate { get; set; }
        public int? mgrid { get; set; }
    }
}
