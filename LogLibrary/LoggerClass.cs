using Microsoft.Extensions.Logging;

namespace LogLibrary
{
    public static class LoggerClass
    {
        public static ILogger _logger { get; set; }
        public static void Log(LogLevel level, string message, string code = "Default", string sessionId = "Default")
        {
            switch (level)
            {
                case LogLevel.TRACE:
                    //if (_logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Trace))
                    //{
                    //    //CUstom
                    //}
                    _logger.LogTrace(message);
                    break;
                case LogLevel.DEBUG:
                    //if (_logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Debug))
                    //{

                    //}
                     _logger.LogDebug(message);
                    break;
                case LogLevel.INFO:
                    //if (_logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Information))
                    //{

                    //}
                    _logger.LogInformation(message);
                    break;
                case LogLevel.WARN:
                    //if (_logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Warning))
                    //{

                    //}
                     _logger.LogWarning(message);
                    break;
                case LogLevel.ERROR:
                    //if (_logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Error))
                    //{

                    //}
                    _logger.LogError(message);
                    break;
                case LogLevel.FATAL:
                default:
                    //if (_logger.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Critical))
                    //{

                    //}
                    _logger.LogCritical(message);
                    break;
            }
        }

    }


}
