using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ImportRuleRequest
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; init; }

    [JsonPropertyName("slug")]
    public required string Slug { get; init; }

    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; init; }

    [JsonPropertyName("testRequest")]
    public Dictionary<string, object> TestRequest { get; init; } = new Dictionary<string, object>();

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("requestSchema")]
    public IEnumerable<object> RequestSchema { get; init; } = new List<object>();

    [JsonPropertyName("responseSchema")]
    public IEnumerable<object> ResponseSchema { get; init; } = new List<object>();

    [JsonPropertyName("sampleRequest")]
    public Dictionary<string, object> SampleRequest { get; init; } =
        new Dictionary<string, object>();

    [JsonPropertyName("sampleResponse")]
    public Dictionary<string, object> SampleResponse { get; init; } =
        new Dictionary<string, object>();

    [JsonPropertyName("conditions")]
    public IEnumerable<object> Conditions { get; init; } = new List<object>();

    [JsonPropertyName("published")]
    public required bool Published { get; init; }

    [JsonPropertyName("history")]
    public IEnumerable<object> History { get; init; } = new List<object>();
}
