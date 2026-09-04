using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ImportManifestPreviewResponsePreviewItemsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("type")]
    public ImportManifestPreviewResponsePreviewItemsItemType? Type { get; set; }

    [JsonPropertyName("source_index")]
    public int? SourceIndex { get; set; }

    [JsonPropertyName("stable_id")]
    public string? StableId { get; set; }

    [JsonPropertyName("operation")]
    public ImportManifestPreviewResponsePreviewItemsItemOperation? Operation { get; set; }

    [JsonPropertyName("final")]
    public Dictionary<string, object?>? Final { get; set; }

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
