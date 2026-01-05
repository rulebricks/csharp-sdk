using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// The exported manifest data.
/// </summary>
[Serializable]
public record ExportManifestResponseManifest : IJsonOnDeserialized
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
    /// Manifest name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Manifest description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("exported_at")]
    public DateTime? ExportedAt { get; set; }

    /// <summary>
    /// Exported contexts.
    /// </summary>
    [JsonPropertyName("contexts")]
    public IEnumerable<Dictionary<string, object?>>? Contexts { get; set; }

    /// <summary>
    /// Exported dynamic values.
    /// </summary>
    [JsonPropertyName("values")]
    public IEnumerable<Dictionary<string, object?>>? Values { get; set; }

    /// <summary>
    /// Exported rules.
    /// </summary>
    [JsonPropertyName("rules")]
    public IEnumerable<Dictionary<string, object?>>? Rules { get; set; }

    /// <summary>
    /// Exported flows.
    /// </summary>
    [JsonPropertyName("flows")]
    public IEnumerable<Dictionary<string, object?>>? Flows { get; set; }

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
