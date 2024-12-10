using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record DeleteFolderRequest
{
    /// <summary>
    /// ID of the folder to delete
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }
}
