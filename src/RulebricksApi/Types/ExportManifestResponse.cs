using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ExportManifestResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Manifest format version.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("exported_at")]
    public DateTime? ExportedAt { get; set; }

    [JsonPropertyName("rules")]
    public IEnumerable<Dictionary<string, object?>>? Rules { get; set; }

    [JsonPropertyName("flows")]
    public IEnumerable<Dictionary<string, object?>>? Flows { get; set; }

    [JsonPropertyName("contexts")]
    public IEnumerable<Dictionary<string, object?>>? Contexts { get; set; }

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
