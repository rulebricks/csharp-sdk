using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record BadRequestErrorBody
{
    /// <summary>
    /// Error message describing the issue with the request.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; init; }
}
