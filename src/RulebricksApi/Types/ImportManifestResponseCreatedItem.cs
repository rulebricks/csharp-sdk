using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ImportManifestResponseCreatedItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Asset type (context, value, rule, flow, relationship).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Stable ID of asset.
    /// </summary>
    [JsonPropertyName("stable_id")]
    public string? StableId { get; set; }

    /// <summary>
    /// Database ID of asset.
    /// </summary>
    [JsonPropertyName("db_id")]
    public string? DbId { get; set; }

    /// <summary>
    /// Import status.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

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
