using RequestConsole.Abstractions;
using RequestConsole.Models;

namespace RequestConsole.Services
{
    internal class ClientService : IClientService
    {
        private readonly IOffersApiOne _offersApiOne;
        private readonly IOffersApiTwo _offersApiTwo;
        private readonly IOffersApiThree _offersApiThree;

        public ClientService(IOffersApiOne? offersApiOne, IOffersApiTwo? offersApiTwo, IOffersApiThree? offersApiThree)
        {
            _offersApiOne = offersApiOne ?? throw new ArgumentNullException(nameof(offersApiOne));
            _offersApiTwo = offersApiTwo ?? throw new ArgumentNullException(nameof(offersApiTwo));
            _offersApiThree = offersApiThree ?? throw new ArgumentNullException(nameof(offersApiThree));
        }
        public async Task<OfferResponse[]?> GetOffers(Request? request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var collectedResponses = new List<Task<OfferResponse>>
            {
                _offersApiOne.GetOffersAsync(request),
                _offersApiTwo.GetOffersAsync(request),
                _offersApiThree.GetOffersAsync(request)
            };

            return await Task.WhenAll(collectedResponses);

        }
    }
}
