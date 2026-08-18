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
    /// Manifest format version.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    /// <summary>
    /// Rules to import.
    /// </summary>
    [JsonPropertyName("rules")]
    public IEnumerable<Dictionary<string, object?>>? Rules { get; set; }

    /// <summary>
    /// Flows to import.
    /// </summary>
    [JsonPropertyName("flows")]
    public IEnumerable<Dictionary<string, object?>>? Flows { get; set; }

    /// <summary>
    /// Contexts to import.
    /// </summary>
    [JsonPropertyName("entities")]
    public IEnumerable<Dictionary<string, object?>>? Entities { get; set; }

    /// <summary>
    /// Alias for `entities`, accepted so manifests produced by the export endpoint (which names this array `contexts`) can be imported without modification. Ignored when `entities` is present and non-empty.
    /// </summary>
    [JsonPropertyName("contexts")]
    public IEnumerable<Dictionary<string, object?>>? Contexts { get; set; }

    /// <summary>
    /// Vocabulary values to import.
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
