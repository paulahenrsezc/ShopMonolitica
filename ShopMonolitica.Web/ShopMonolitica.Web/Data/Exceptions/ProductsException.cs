namespace ShopMonolitica.Web.Data.Exceptions
{
    public class ProductsException : Exception
    {
        public ProductsException(string message): base (message) 
        {
            //Logica para guardar el error en la base datos y enviar correo
        }
    }
}
