using ShopMonolitica.Web.Data.interfaces;

namespace ShopMonolitica.Web.Data.DbObjects
{
    public class LoggerDb<T> : ILoggerDb<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerDb(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogError(string message, string exception)
        {
            _logger.LogError($"{message} - Exception: {exception}");
        }
    }
}
