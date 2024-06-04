namespace ShopMonolitica.Web.BL.Exceptions
{
    public class Categories : Exception
    {
        public Categories(string message) : base(message)
        {

        }

        public string categoryname { get; internal set; }
        public string description { get; internal set; }
        public DateTime creation_date { get; internal set; }
    }
}
