using Microsoft.AspNetCore.Server.Kestrel.Core;
using UserService.Options;

namespace UserService.Extensions;

public static class KestrelConfigurationExtensions
{
    public static IWebHostBuilder ConfigureKestrelWithOptions(this IWebHostBuilder webHostBuilder)
    {
        return webHostBuilder.ConfigureKestrel((context, options) =>
        {
            var kestrelConfig = context.Configuration
                .GetSection(nameof(KestrelConfigOptions))
                .Get<KestrelConfigOptions>();

            if (kestrelConfig?.PortConfigs != null)
            {
                foreach (var endpoint in kestrelConfig.PortConfigs)
                {
                    options.ListenAnyIP(
                        int.Parse(endpoint.Port),
                        listenOptions =>
                        {
                            listenOptions.Protocols = endpoint.Protocol switch
                            {
                                "Http2" => HttpProtocols.Http2,
                                "Http1" => HttpProtocols.Http1,
                                _ => throw new InvalidOperationException($"Unknown protocol: {endpoint.Protocol}")
                            };
                        });
                }
            }
        });
    }
}