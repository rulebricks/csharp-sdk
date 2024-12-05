using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ImportRuleResponse
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("slug")]
    public string? Slug { get; init; }
}
