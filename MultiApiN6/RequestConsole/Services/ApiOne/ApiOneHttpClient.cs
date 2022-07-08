using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RequestConsole.Abstractions;
using RequestConsole.Models;

namespace RequestConsole.Services.ApiOne;

internal class ApiOneHttpClient : BaseHttpClient<ApiOneServiceClientOptions>, IOffersApiOne
{
    public ApiOneHttpClient(HttpClient httpClient, IOptionsMonitor<ApiOneServiceClientOptions> options) : base(httpClient, options)
    {
    }

    public async Task<OfferResponse> GetOffersAsync(Request request)
    {
        var jsonString = JsonSerializer.Serialize(request);

        HttpResponseMessage responseMessage = await HttpClient.PostAsync($"{Options.CurrentValue.BaseServiceUrl}/api/Request",
            new StringContent(jsonString, Encoding.UTF8, "application/json"));

        if (responseMessage.IsSuccessStatusCode)
        {
            var stringMessage = await responseMessage.Content.ReadAsStringAsync();
            var offer = JsonSerializer.Deserialize<JsonResponseOne>(stringMessage);
            if (offer is not null)
                return new OfferResponse
                {
                    Source = ApiSource.JsonApiOne,
                    Offer = offer.Total.GetValueOrDefault()
                };
        }

        return new OfferResponse
        {
            Source = ApiSource.JsonApiOne,
            Offer = 0
        };
    }
}