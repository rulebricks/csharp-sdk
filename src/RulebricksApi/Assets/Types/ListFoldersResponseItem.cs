using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ListFoldersResponseItem
{
    /// <summary>
    /// Unique identifier for the folder.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Name of the folder.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Description of the folder.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Timestamp of when the folder was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; init; }
}
