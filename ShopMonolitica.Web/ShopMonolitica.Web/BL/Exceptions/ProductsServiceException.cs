namespace ShopMonolitica.Web.BL.Exceptions
{
    public class ProductsServiceException: Exception
    {
        public ProductsServiceException(string message) : base(message)
        {
            //Logica para guardar el error en la base datos y enviar correo
        }
    }
}
