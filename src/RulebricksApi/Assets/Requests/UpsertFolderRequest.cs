using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record UpsertFolderRequest
{
    /// <summary>
    /// Folder ID (required for updates, omit for creation)
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Name of the folder
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Description of the folder
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }
}
