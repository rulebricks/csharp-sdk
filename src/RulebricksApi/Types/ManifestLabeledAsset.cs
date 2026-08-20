using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A rule or flow entry in an RBM manifest. The full asset document is preserved for round-trip compatibility.
/// </summary>
[Serializable]
public record ManifestLabeledAsset : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("data")]
    public ManifestLabeledAssetData? Data { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
