using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record NotFoundErrorBody
{
    /// <summary>
    /// Error message indicating the value was not found.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; init; }
}
