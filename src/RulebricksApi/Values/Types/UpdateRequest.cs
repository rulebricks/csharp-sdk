using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RulebricksApi.Values.Types
{
    public class UpdateRequest
    {
        [JsonPropertyName("values")]
        public Dictionary<string, UpdateRequestValue> Values { get; set; } = new();
    }
}
