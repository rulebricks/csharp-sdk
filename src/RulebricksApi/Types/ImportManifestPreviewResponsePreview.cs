using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ImportManifestPreviewResponsePreview : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("policy")]
    public required ImportManifestPreviewResponsePreviewPolicy Policy { get; set; }

    [JsonPropertyName("executable")]
    public required bool Executable { get; set; }

    [JsonPropertyName("partial")]
    public bool? Partial { get; set; }

    [JsonPropertyName("summary")]
    public Dictionary<string, int> Summary { get; set; } = new Dictionary<string, int>();

    [JsonPropertyName("items")]
    public IEnumerable<ImportManifestPreviewResponsePreviewItemsItem> Items { get; set; } =
        new List<ImportManifestPreviewResponsePreviewItemsItem>();

    [JsonPropertyName("issues")]
    public IEnumerable<Dictionary<string, object?>> Issues { get; set; } =
        new List<Dictionary<string, object?>>();

    [JsonPropertyName("warnings")]
    public IEnumerable<string>? Warnings { get; set; }

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
