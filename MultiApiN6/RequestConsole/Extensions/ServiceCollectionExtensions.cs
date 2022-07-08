using Microsoft.Extensions.DependencyInjection;
using RequestConsole.Abstractions;
using RequestConsole.Services;
using RequestConsole.Services.ApiOne;
using RequestConsole.Services.ApiThree;
using RequestConsole.Services.ApiTwo;

namespace RequestConsole.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddSingleton<IProcessor, RequestProcessor>()
                .AddSingleton<IClientService, ClientService>()
                .AddSingleton<IInputReader, InputReader>();

            return services;
        }

        public static IServiceCollection AddApiOneService(this IServiceCollection services,
            Action<ApiOneServiceClientOptions>? configureOptions)
        {
            //services.AddOptions<ApiOneServiceClientOptions>()
            //    .Configure(configureOptions);

            services.AddHttpClient<IOffersApiOne, ApiOneHttpClient>((provider, client) =>
            {
                client.BaseAddress = new("https://localhost:7174");
            });

            return services;
        }

        public static IServiceCollection AddApiTwoService(this IServiceCollection services,
            Action<ApiOneServiceClientOptions>? configureOptions)
        {
            services.AddHttpClient<IOffersApiTwo, ApiTwoHttpClient>((provider, client) =>
            {
                client.BaseAddress = new("https://localhost:7112");
            });


            return services;
        }


        public static IServiceCollection AddApiThreeService(this IServiceCollection services,
            Action<ApiThreeServiceClientOptions>? configureOptions)
        {
            services.AddHttpClient<IOffersApiThree, ApiThreeHttpClient>((provider, client) =>
            {
                client.BaseAddress = new("https://localhost:7091");
            });


            return services;
        }
    }
}
