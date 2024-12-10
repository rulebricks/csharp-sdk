using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record UpsertFolderResponse
{
    /// <summary>
    /// ID of the created or updated folder
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Name of the folder
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Description of the folder
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Timestamp of when the folder was updated
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; init; }
}
