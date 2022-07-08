using Microsoft.Extensions.Options;
using RequestConsole.Abstractions;

namespace RequestConsole.Services
{
    internal abstract class BaseHttpClient<TOptions> : IHttpServiceClient
        where TOptions : ServiceClientOptions
    {
        protected readonly HttpClient HttpClient;
        protected readonly IOptionsMonitor<TOptions> Options;

        protected BaseHttpClient(HttpClient httpClient, IOptionsMonitor<TOptions> options)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
