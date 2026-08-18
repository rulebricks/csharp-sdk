using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ExportManifestRequest
{
    /// <summary>
    /// The type of root asset to export. All dependencies will be included.
    /// </summary>
    [JsonPropertyName("root_type")]
    public required ExportManifestRequestRootType RootType { get; set; }

    /// <summary>
    /// Array of IDs for the root assets to export. Dependencies are automatically resolved.
    /// </summary>
    [JsonPropertyName("root_ids")]
    public IEnumerable<string> RootIds { get; set; } = new List<string>();

    /// <summary>
    /// For context exports, whether to include rules and flows bound to the context.
    /// </summary>
    [JsonPropertyName("include_downstream")]
    public bool? IncludeDownstream { get; set; }

    /// <summary>
    /// Optional name for the exported manifest.
    /// </summary>
    [JsonPropertyName("manifest_name")]
    public string? ManifestName { get; set; }

    /// <summary>
    /// Optional description for the exported manifest.
    /// </summary>
    [JsonPropertyName("manifest_description")]
    public string? ManifestDescription { get; set; }

    /// <summary>
    /// If true, returns a preview of what would be exported without the full data.
    /// </summary>
    [JsonPropertyName("preview_only")]
    public bool? PreviewOnly { get; set; }

    /// <summary>
    /// If true, the manifest in the response is returned in compressed form: the JSON array produced by the compress-json library instead of a plain object. Compressed manifests are substantially smaller, can be saved directly as a .rbm file, and are accepted by the import endpoint as-is. Intended for raw HTTP usage and file tooling; typed SDK clients should omit this flag, since the generated response type models the manifest as an object.
    /// </summary>
    [JsonPropertyName("compress")]
    public bool? Compress { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
