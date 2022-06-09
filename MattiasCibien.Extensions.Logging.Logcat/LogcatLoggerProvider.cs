using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Runtime.Versioning;

namespace MattiasCibien.Extensions.Logging.Logcat
{
    [UnsupportedOSPlatform("windows")]
    [UnsupportedOSPlatform("browser")]
    [UnsupportedOSPlatform("ios")]
    [ProviderAlias("ColorConsole")]
    internal class LogcatLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, LogcatLogger> _loggers = new(StringComparer.OrdinalIgnoreCase);
        private readonly string _tag;

        public LogcatLoggerProvider(string tag)
        {
            _tag = tag;
        }

        public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new LogcatLogger(_tag, name));

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
