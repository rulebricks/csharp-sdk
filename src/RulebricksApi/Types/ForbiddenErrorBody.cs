using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ForbiddenErrorBody
{
    [JsonPropertyName("error")]
    public string? Error { get; init; }
}
