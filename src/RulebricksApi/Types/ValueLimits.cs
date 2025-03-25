using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// System limits for dynamic values
/// </summary>
public record ValueLimits
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
