using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ListGroupsResponseItem
{
    /// <summary>
    /// Unique identifier of the user group.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Name of the user group.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Description of the user group.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// List of member emails in the user group.
    /// </summary>
    [JsonPropertyName("members")]
    public IEnumerable<string>? Members { get; init; }
}
