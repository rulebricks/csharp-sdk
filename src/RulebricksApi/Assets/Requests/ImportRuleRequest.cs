using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ImportRuleRequest
{
    /// <summary>
    /// The rule data to import.
    /// </summary>
    [JsonPropertyName("rule")]
    public Dictionary<string, object> Rule { get; init; } = new Dictionary<string, object>();
}
