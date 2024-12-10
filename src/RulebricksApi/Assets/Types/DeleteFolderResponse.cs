using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record DeleteFolderResponse
{
    /// <summary>
    /// ID of the deleted folder
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Name of the deleted folder
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Description of the deleted folder
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Last update timestamp of the deleted folder
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; init; }
}
