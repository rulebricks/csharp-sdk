using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ImportManifestRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The RBM manifest object containing assets to import. Asset objects inside the manifest intentionally preserve `.rbm`/database casing so exported manifests can be imported without rewriting asset payloads. A compressed manifest is also accepted: the JSON array produced by the compress-json library (for example, the contents of a compressed .rbm file exported with `compress: true`); it is detected and decompressed automatically.
    /// </summary>
    [JsonPropertyName("manifest")]
    public required ImportManifestRequestManifest Manifest { get; set; }

    /// <summary>
    /// How to handle assets in the manifest that already exist in the workspace (matched by stable ID, or by name for contexts). 'override' replaces them in place, keeping their workspace ID, slug, folder and access groups but taking the manifest's content and version history (existing versions and their release pins are dropped; contexts are deleted with their stored records and recreated). 'preserve' keeps existing assets unchanged and reuses them for new dependents. 'block' rejects the whole import before any write if anything already exists. Object-managed values are never written.
    /// </summary>
    [JsonPropertyName("conflict_strategy")]
    public ImportManifestRequestConflictStrategy? ConflictStrategy { get; set; }

    /// <summary>
    /// Optional folder name to place imported assets into. Created if it doesn't exist.
    /// </summary>
    [JsonPropertyName("target_folder_name")]
    public string? TargetFolderName { get; set; }

    /// <summary>
    /// Optional parent folder for imported asset folders.
    /// </summary>
    [JsonPropertyName("parent_folder_id")]
    public string? ParentFolderId { get; set; }

    /// <summary>
    /// Clear imported edit history, typically for templates.
    /// </summary>
    [JsonPropertyName("clear_history")]
    public bool? ClearHistory { get; set; }

    /// <summary>
    /// Return the server-authoritative create/reuse/reject plan without writing.
    /// </summary>
    [JsonPropertyName("preview_only")]
    public bool? PreviewOnly { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
