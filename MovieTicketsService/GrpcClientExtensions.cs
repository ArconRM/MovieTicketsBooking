using MovieTicketsService.Options;

namespace MovieTicketsService;

using Grpc.Core;
using Microsoft.Extensions.Options;

public static class GrpcClientExtensions
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        // Настройка GrpcClientOptions из конфигурации
        services.Configure<GrpcClientOptions>(configuration.GetSection(nameof(GrpcClientOptions)));

        // Настройка клиента для UserService
        services.AddGrpcClient<Common.Protos.UserService.UserServiceClient>((serviceProvider, options) =>
            {
                var grpcOptions = serviceProvider.GetRequiredService<IOptions<GrpcClientOptions>>().Value;
                options.Address = new Uri(grpcOptions.UserServiceUrl);
            })
            .ConfigureChannel(options => { options.Credentials = ChannelCredentials.Insecure; });

        return services;
    }
}