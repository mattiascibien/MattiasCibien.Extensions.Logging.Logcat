using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AndroidLog = Android.Util.Log;

namespace MattiasCibien.Extensions.Logging.Logcat
{
    public sealed class LogcatLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly string _tag;

        public LogcatLogger(string tag, string categoryName)
        {
            _tag = tag;
            _categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state) => default!;

        public bool IsEnabled(LogLevel logLevel) => AndroidLog.IsLoggable(_tag, MapLogLevel(logLevel));

        private static Android.Util.LogPriority MapLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    return Android.Util.LogPriority.Verbose;
                case LogLevel.Debug:
                    return Android.Util.LogPriority.Debug;
                case LogLevel.Information:
                    return Android.Util.LogPriority.Info;
                case LogLevel.Warning:
                    return Android.Util.LogPriority.Warn;
                case LogLevel.Error:
                    return Android.Util.LogPriority.Error;
                case LogLevel.Critical:
                    return Android.Util.LogPriority.Error;
                case LogLevel.None:
                    return Android.Util.LogPriority.Info;
            }

            return Android.Util.LogPriority.Info;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    AndroidLog.Verbose(_tag, $"[{_categoryName}] {formatter(state, exception)}");
                    break;
                case LogLevel.Debug:
                    AndroidLog.Debug(_tag, $"[{_categoryName}] {formatter(state, exception)}");
                    break;
                case LogLevel.Information:
                    AndroidLog.Info(_tag, $"[{_categoryName}] {formatter(state, exception)}");
                    break;
                case LogLevel.Warning:
                    AndroidLog.Warn(_tag, $"[{_categoryName}] {formatter(state, exception)}");
                    break;
                case LogLevel.Error:
                    AndroidLog.Error(_tag, $"[{_categoryName}] {formatter(state, exception)}");
                    break;
                case LogLevel.Critical:
                    AndroidLog.Error(_tag, $"[{_categoryName}] {formatter(state, exception)}");
                    break;
                case LogLevel.None:
                    AndroidLog.Info(_tag, $"[{_categoryName}] {formatter(state, exception)}");
                    break;
                default:
                    break;
            }
        }
    }
}
