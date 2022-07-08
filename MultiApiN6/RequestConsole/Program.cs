// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RequestConsole.Abstractions;
using RequestConsole.Extensions;
using Microsoft.Extensions.Configuration;

namespace RequestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
            var filePath = config.GetSection("FilePath").Value;

            var processor = host.Services.GetService<IProcessor>();

            if (processor is not null)
                await processor.Process(filePath);
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                services
                    .AddAutoMapper(typeof(Program))
                    .AddHttpClient()
                    .AddApplicationServices()
                    .AddApiOneService(options => { })
                    .AddApiTwoService(options => { })
                    .AddApiThreeService(options => { })
                );
    }
}