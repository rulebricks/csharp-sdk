using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Preview of assets that would be exported. The preview wrapper uses snake_case, while asset items intentionally preserve `.rbm`/database casing (for example, `valueType` and `updatedAt`) because the same items feed manifest preview/import UI.
/// </summary>
[Serializable]
public record ExportManifestPreviewResponsePreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("counts")]
    public ExportManifestPreviewResponsePreviewCounts? Counts { get; set; }

    [JsonPropertyName("items")]
    public ExportManifestPreviewResponsePreviewItems? Items { get; set; }

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
