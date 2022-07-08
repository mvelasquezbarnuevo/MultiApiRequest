using RequestConsole.Services;

namespace RequestConsole.Models;

internal class OfferResponse
{
    public ApiSource Source { get; set; }
    public decimal Offer { get; set; }
}