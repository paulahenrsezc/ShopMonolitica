namespace ShopMonolitica.Web.BL.Core
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            this.Succes = true;
        }
        public bool Succes { get; set; }
        public string? message { get; set; }
        public dynamic? Data { get; set; }

    }

}
