using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace ShopMonolitica.Web.Data.Exceptions
{
    public class SuppliersException: Exception
    {
        public SuppliersException(string message): base(message)
        {
            //Logica para guardar el error en la base datos y enviar correo
        }
    }

}
