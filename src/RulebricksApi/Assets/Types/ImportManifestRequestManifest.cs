using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// The RBM manifest object containing assets to import.
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
    /// Contexts (entities) to import.
    /// </summary>
    [JsonPropertyName("contexts")]
    public IEnumerable<Dictionary<string, object?>>? Contexts { get; set; }

    /// <summary>
    /// Dynamic values to import.
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
