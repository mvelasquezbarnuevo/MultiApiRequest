using System.Runtime.CompilerServices;
using RequestConsole.Models;
[assembly: InternalsVisibleTo("Unit.Tests")]

namespace RequestConsole.Abstractions
{
    internal interface IClientService
    {
        Task<OfferResponse[]?> GetOffers(Request? request);
    }
}