using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record DeleteRuleRequest
{
    /// <summary>
    /// The ID of the rule to delete.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }
}
