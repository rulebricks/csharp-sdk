using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record InternalServerErrorBody
{
    /// <summary>
    /// Error message describing the internal server error.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; init; }
}
