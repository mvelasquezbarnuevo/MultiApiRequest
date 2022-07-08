using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using RequestConsole.Abstractions;
using RequestConsole.Extensions;
using RequestConsole.Models;

namespace RequestConsole.Services.ApiTwo;

internal class ApiTwoHttpClient : BaseHttpClient<ApiTwoServiceClientOptions>, IOffersApiTwo
{
    private readonly IMapper _mapper;

    public ApiTwoHttpClient(HttpClient httpClient, IOptionsMonitor<ApiTwoServiceClientOptions> options, IMapper mapper)
        : base(httpClient, options)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<OfferResponse> GetOffersAsync(Request request)
    {
        var xmlRequest = _mapper.Map<XmlRequest>(request);

        var xmlString = xmlRequest.ToXml();

        var stringContent = new StringContent(xmlString, Encoding.UTF8, "application/xml");
        var responseMessage = await HttpClient.PostAsync($"{Options.CurrentValue.BaseServiceUrl}/api/Request", stringContent);
        
        if (responseMessage.IsSuccessStatusCode)
        {
            var stringMessage = await responseMessage.Content.ReadAsStringAsync();
            var xmlResponse = stringMessage.DeserializeXml<XmlResponse>();

            if (xmlResponse is not null)
            {
                return new OfferResponse
                {
                    Source = ApiSource.XmlApiTwo,
                    Offer = xmlResponse.Amount.GetValueOrDefault()
                };
            }
        }

        return new OfferResponse
        {
            Source = ApiSource.XmlApiTwo,
            Offer = 0
        };
    }
}