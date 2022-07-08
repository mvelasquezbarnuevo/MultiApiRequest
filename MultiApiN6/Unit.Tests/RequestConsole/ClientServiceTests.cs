using Moq;
using RequestConsole.Abstractions;
using RequestConsole.Models;
using RequestConsole.Services;

namespace Unit.Tests.RequestConsole
{
    public class ClientServiceTests
    {
        private readonly ClientService _clientService;
        private readonly Mock<IOffersApiOne> _offersApiOneMock;
        private readonly Mock<IOffersApiTwo> _offersApiTwoMock;
        private readonly Mock<IOffersApiThree> _offersApiThreeMock;

        public ClientServiceTests()
        {
            _offersApiOneMock = new Mock<IOffersApiOne>();
            _offersApiTwoMock = new Mock<IOffersApiTwo>();
            _offersApiThreeMock = new Mock<IOffersApiThree>();
            _clientService = new ClientService(_offersApiOneMock.Object, _offersApiTwoMock.Object, _offersApiThreeMock.Object);
        }

        [Fact]
        public void Can_Be_Initialized()
        {
            Assert.NotNull(_clientService);
            Assert.IsAssignableFrom<IClientService>(_clientService);
        }

        [Fact]
        public async Task ThrowsException_When_NullRequest()
        {
            _ = await Assert.ThrowsAsync<ArgumentNullException>(() => _clientService.GetOffers(null));
        }

        [Fact]
        public void ThrowsException_When_NullApiOne()
        {
            _ =  Assert.Throws<ArgumentNullException>(() => new ClientService(null, _offersApiTwoMock.Object, _offersApiThreeMock.Object));
        }

        [Fact]
        public void ThrowsException_When_NullApiTwo()
        {
            _ = Assert.Throws<ArgumentNullException>(() => new ClientService(_offersApiOneMock.Object, null, _offersApiThreeMock.Object));
        }

        [Fact]
        public async Task ValidRequest_Returns_ValidOffers()
        {
            _offersApiOneMock.Setup(x => x.GetOffersAsync(It.IsAny<Request>()))
                .Returns(Task.FromResult(new OfferResponse { Offer = 100, Source = ApiSource.JsonApiOne }));

            _offersApiTwoMock.Setup(x => x.GetOffersAsync(It.IsAny<Request>()))
                .Returns(Task.FromResult(new OfferResponse { Offer = 200, Source = ApiSource.XmlApiTwo }));

            _offersApiThreeMock.Setup(x => x.GetOffersAsync(It.IsAny<Request>()))
                .Returns(Task.FromResult(new OfferResponse { Offer = 90, Source = ApiSource.JsonApiThree }));

            var offers = await _clientService.GetOffers(new Request());

            Assert.NotNull(offers);
            Assert.Equal(3, offers?.Length);
        }
    }
}
