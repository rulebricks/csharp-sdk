using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RulebricksApi.Values.Types
{
    public class UpdateRequestValue
    {
        [JsonPropertyName("string")]
        public string? StringValue { get; set; }
        [JsonPropertyName("number")]
        public double? NumberValue { get; set; }
        [JsonPropertyName("boolean")]
        public bool? BooleanValue { get; set; }
        [JsonPropertyName("list")]
        public IEnumerable<object>? ListValue { get; set; }
    }
}
