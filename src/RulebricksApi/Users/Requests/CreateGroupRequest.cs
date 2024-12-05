using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record CreateGroupRequest
{
    /// <summary>
    /// Unique name of the user group.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Description of the user group.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }
}
