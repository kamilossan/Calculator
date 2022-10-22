using Newtonsoft.Json;

namespace Calculator.Models
{
    public class CalculatorRequestResponse
    {
        [JsonProperty("error", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Error { get; set; }
        [JsonProperty("result", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal? Result { get; set; }

        [JsonIgnore]
        public bool IsError => Error != null;
    }
}
