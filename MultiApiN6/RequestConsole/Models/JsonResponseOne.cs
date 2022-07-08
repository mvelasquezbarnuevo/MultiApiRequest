using System.Text.Json.Serialization;

namespace RequestConsole.Models
{
    internal class JsonResponseOne
    {
        [JsonPropertyName("total")]
        public decimal? Total { get; set; }
    }
}
