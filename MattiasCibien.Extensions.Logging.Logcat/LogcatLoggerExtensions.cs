using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace MattiasCibien.Extensions.Logging.Logcat
{
    public static class LogcatLoggerExtensions
    {
        public static ILoggingBuilder AddLogcat(this ILoggingBuilder builder, string tag)
        {
            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, LogcatLoggerProvider>(provider => new LogcatLoggerProvider(tag)));

            return builder;
        }
    }
}
