using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Count of skipped assets by type (already exist and overwrite=false).
/// </summary>
[Serializable]
public record ImportManifestResponseSkipped : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("rules")]
    public int? Rules { get; set; }

    [JsonPropertyName("flows")]
    public int? Flows { get; set; }

    [JsonPropertyName("contexts")]
    public int? Contexts { get; set; }

    [JsonPropertyName("values")]
    public int? Values { get; set; }

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
