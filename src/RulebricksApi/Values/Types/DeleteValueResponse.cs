using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record DeleteValueResponse
{
    /// <summary>
    /// Confirmation message of successful deletion.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
