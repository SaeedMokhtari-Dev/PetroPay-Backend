using NLog;
using NLog.Config;

namespace PetroPay.Web.Logging.Base
{
    public abstract class LoggerBase
    {
        static LoggerBase()
        {
            LogManager.ThrowConfigExceptions = true;
            LogManager.Configuration = new LoggingConfiguration();
        }
    }
}
