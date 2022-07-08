using System.Text.Json.Serialization;

namespace RequestConsole.Models
{
    public class Request
    {
        [JsonPropertyName("sourceAddress")]
        public string? SourceAddress { get; set; }
        [JsonPropertyName("destinationAddress")]
        public string? DestinationAddress { get; set; }
        [JsonPropertyName("cartonDimensions")]
        public Dimension[]? CartonDimensions { get; set; }

    }

    public class Dimension
    {
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
    }
}
