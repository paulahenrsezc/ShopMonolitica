namespace ShopMonolitica.Web.BL.Core
{
    public class ServiceResult
    {
        public ServiceResult()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public string? Menssage { get; set; }
        public dynamic? Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
