using System.Text;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Options;
using RequestConsole.Abstractions;
using RequestConsole.Models;
using RequestConsole.Services.ApiOne;

namespace RequestConsole.Services.ApiThree
{
    internal class ApiThreeHttpClient : BaseHttpClient<ApiOneServiceClientOptions>, IOffersApiThree
    {
        private readonly IMapper _mapper;

        public ApiThreeHttpClient(HttpClient httpClient, IOptionsMonitor<ApiOneServiceClientOptions> options, IMapper mapper) : base(httpClient, options)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<OfferResponse> GetOffersAsync(Request request)
        {
            var jsonThree = _mapper.Map<JsonThreeRequest>(request);
            var jsonString = JsonSerializer.Serialize(jsonThree);

            HttpResponseMessage responseMessage = await HttpClient.PostAsync($"{Options.CurrentValue.BaseServiceUrl}/api/Request",
                new StringContent(jsonString, Encoding.UTF8, "application/json"));

            if (responseMessage.IsSuccessStatusCode)
            {
                var stringMessage = await responseMessage.Content.ReadAsStringAsync();
                var offer = JsonSerializer.Deserialize<JsonResponseThree>(stringMessage);
                if (offer is not null)
                    return new OfferResponse
                    {
                        Source = ApiSource.JsonApiThree,
                        Offer = offer.Amount.GetValueOrDefault()
                    };
            }

            return new OfferResponse
            {
                Source = ApiSource.JsonApiThree,
                Offer = 0
            };
        }
    }
}
