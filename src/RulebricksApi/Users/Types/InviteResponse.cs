using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record InviteResponse
{
    [JsonPropertyName("message")]
    public string? Message { get; init; }
}
