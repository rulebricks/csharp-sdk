using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// System limits for dynamic values
/// </summary>
[Serializable]
public record ValueLimits : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Maximum number of value keys per user
    /// </summary>
    [JsonPropertyName("MAX_KEYS")]
    public int? MaxKeys { get; set; }

    /// <summary>
    /// Maximum length of a single value in characters
    /// </summary>
    [JsonPropertyName("MAX_VALUE_LENGTH")]
    public int? MaxValueLength { get; set; }

    /// <summary>
    /// Maximum total size of all values in bytes
    /// </summary>
    [JsonPropertyName("MAX_TOTAL_SIZE")]
    public int? MaxTotalSize { get; set; }

    /// <summary>
    /// Maximum length of a key name
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
