using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// System limits for vocabulary values
/// </summary>
[Serializable]
public record ValueLimits : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Maximum number of vocabulary values per workspace (a guardrail against runaway imports; the system is designed to operate at this scale)
    /// </summary>
    [JsonPropertyName("MAX_KEYS")]
    public int? MaxKeys { get; set; }

    /// <summary>
    /// Maximum serialized length of a single value payload in characters
    /// </summary>
    [JsonPropertyName("MAX_VALUE_LENGTH")]
    public int? MaxValueLength { get; set; }

    /// <summary>
    /// Maximum length of a value name in characters, including collection prefixes
    /// </summary>
    [JsonPropertyName("MAX_KEY_LENGTH")]
    public int? MaxKeyLength { get; set; }

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
