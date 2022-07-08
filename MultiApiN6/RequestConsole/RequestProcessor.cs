using RequestConsole.Abstractions;
using RequestConsole.Models;
using System.Text.Json;

namespace RequestConsole
{
    internal class RequestProcessor : IProcessor
    {
        private readonly IInputReader _inputReader;
        private readonly IClientService _clientService;

        public RequestProcessor(IInputReader inputReader, IClientService clientService)
        {
            _inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }
        public async Task Process()
        {
            try
            {
                string filePath = "file.txt";
                Console.WriteLine($"Reading input data from file: {filePath}");
                var jsonString = _inputReader.Read(filePath);

                Request? request = JsonSerializer.Deserialize<Request>(jsonString);

                var offers = await _clientService.GetOffers(request);

                if (offers is not null)
                {
                    foreach (var offer in offers)
                    {
                        Console.WriteLine($"Offer received: {offer?.Offer}, from API: {offer?.Source}.");
                    }

                    var bestOffer = offers?.OrderBy(x => x.Offer).First();

                    Console.WriteLine($"Best offer: {bestOffer?.Offer}, from API: {bestOffer?.Source}.");
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
