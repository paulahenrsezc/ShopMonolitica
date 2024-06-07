
namespace ShopMonolitica.Web.Data.Models
{
    public class ShipperSaveModel
    {
        public string? categoryname { get; set; }
        public string? description { get; set; }
        public DateTime creation_date { get; set; }
        public string phone { get; internal set; }
        public string companyname { get; internal set; }
    }
}
