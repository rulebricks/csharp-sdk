using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ImportManifestRequest
{
    /// <summary>
    /// The RBM manifest object containing assets to import.
    /// </summary>
    [JsonPropertyName("manifest")]
    public required ImportManifestRequestManifest Manifest { get; set; }

    /// <summary>
    /// Whether to overwrite existing assets with the same ID/slug.
    /// </summary>
    [JsonPropertyName("overwrite")]
    public bool? Overwrite { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
