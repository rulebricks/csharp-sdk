using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record QueryResponse
{
    [JsonPropertyName("data")]
    public IEnumerable<Dictionary<string, object>>? Data { get; init; }

    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
}
