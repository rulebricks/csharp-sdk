using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Optional single-field rename hint for an update. When `content` replaces an existing schema field key with a new key, this hint preserves matching managed enum value IDs instead of archiving and recreating them.
/// </summary>
[Serializable]
public record UpsertObjectRequestFieldRename : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Previous schema field key or schemaPath present on the stored object.
    /// </summary>
    [JsonPropertyName("from_key")]
    public required string FromKey { get; set; }

    /// <summary>
    /// Replacement schema field key or schemaPath present in the submitted content.
    /// </summary>
    [JsonPropertyName("to_key")]
    public required string ToKey { get; set; }

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
