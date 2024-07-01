namespace ShopMonolitica.Web.Data.interfaces
{
    public interface ILoggerDb<T>
    {
        void LogError(string message, string exception);
    }
}
