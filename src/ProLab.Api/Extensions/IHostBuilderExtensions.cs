using Serilog;

namespace ProLab.Api.Extensions;

public static class IHostBuilderExtensions
{
    public static IHostBuilder SerilogConfiguration(this IHostBuilder hostBuilder)
    {
        _ = hostBuilder.UseSerilog((context, loggerConfig) =>
            loggerConfig.ReadFrom.Configuration(context.Configuration)
        );

        return hostBuilder;
    }
}
