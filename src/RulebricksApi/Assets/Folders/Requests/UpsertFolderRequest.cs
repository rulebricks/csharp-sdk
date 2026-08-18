using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[Serializable]
public record UpsertFolderRequest
{
    /// <summary>
    /// Folder ID (required for updates, omit for creation)
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Name of the folder
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Description of the folder
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The type of assets the folder organizes. Applies on creation; ignored when updating an existing folder.
    /// </summary>
    [JsonPropertyName("type")]
    public UpsertFolderRequestType? Type { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
