namespace ShopMonolitica.Web.BL.Exceptions
{
    public class Shippers : Exception
    {
        public Shippers(string message) : base(message)
        {

        }

        public string phone { get; internal set; }
        public string companyname { get; internal set; }
    }
}

