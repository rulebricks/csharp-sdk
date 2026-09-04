using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// The RBM manifest object containing assets to import. Asset objects inside the manifest intentionally preserve `.rbm`/database casing so exported manifests can be imported without rewriting asset payloads. A compressed manifest is also accepted: the JSON array produced by the compress-json library (for example, the contents of a compressed .rbm file exported with `compress: true`); it is detected and decompressed automatically.
/// </summary>
[Serializable]
public record ImportManifestRequestManifest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// RBM schema version. Unknown fields from newer schemas are preserved with a warning.
    /// </summary>
    [JsonPropertyName("schema_version")]
    public int? SchemaVersion { get; set; }

    /// <summary>
    /// Rules to import.
    /// </summary>
    [JsonPropertyName("rules")]
    public IEnumerable<ManifestLabeledAsset>? Rules { get; set; }

    /// <summary>
    /// Flows to import.
    /// </summary>
    [JsonPropertyName("flows")]
    public IEnumerable<ManifestLabeledAsset>? Flows { get; set; }

    /// <summary>
    /// Legacy alias for `contexts`; accepted and normalized by the RBM codec.
    /// </summary>
    [JsonPropertyName("entities")]
    public IEnumerable<Dictionary<string, object?>>? Entities { get; set; }

    /// <summary>
    /// Contexts to import.
    /// </summary>
    [JsonPropertyName("contexts")]
    public IEnumerable<Dictionary<string, object?>>? Contexts { get; set; }

    /// <summary>
    /// Vocabulary values to import. Entries in object-managed namespaces are skipped and reported instead of being overwritten.
    /// </summary>
    [JsonPropertyName("values")]
    public IEnumerable<Dictionary<string, object?>>? Values { get; set; }

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
