namespace ShopMonolitica.Web.Data.Models.Orders
{
    public class OrdersBaseModel
    {
        public int empid { get; set; }
        public int? custid { get; set; }
        public int shipperid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime? shippeddate { get; set; }
        public decimal freight { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
        public string? shipregion { get; set; }
        public string? shippostalcode { get; set; }
        public string shipcountry { get; set; }
    }
}
