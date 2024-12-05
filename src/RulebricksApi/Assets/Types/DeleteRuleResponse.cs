using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record DeleteRuleResponse
{
    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
