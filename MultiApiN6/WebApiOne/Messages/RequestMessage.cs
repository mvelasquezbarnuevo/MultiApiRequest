using System.Text.Json.Serialization;

namespace WebApiOne.Messages
{
    public class RequestMessage
    {
        public string? SourceAddress { get; set; }
        public string? DestinationAddress { get; set; }
        public Dimension[]? CartonDimensions { get; set; }
    }
    public class Dimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
