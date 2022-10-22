using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Calculator.Models
{
    public class CalculatorRequest
    {
        [JsonProperty("operation")]
        public string? Operation { get; set; }
        [JsonProperty("parameters")]
        public decimal[]? Parameters { get; set; }

    }
}
