using System.Text.Json.Serialization;

namespace RequestConsole.Models
{
    internal class JsonResponseThree
    {
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }
    }
}
