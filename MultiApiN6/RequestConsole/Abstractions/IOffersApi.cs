using System.Runtime.CompilerServices;
using RequestConsole.Models;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace RequestConsole.Abstractions;

internal interface IOffersApi
{
    Task<OfferResponse> GetOffersAsync(Request request);
}