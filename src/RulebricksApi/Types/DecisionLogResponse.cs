using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Response containing decision logs or a count. Returns either {data, cursor} for log queries OR {count} for count queries - these are mutually exclusive based on the count parameter.
/// </summary>
[Serializable]
public record DecisionLogResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of decision log entries. Only present when count parameter is not 'true'.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<DecisionLog>? Data { get; set; }

    /// <summary>
    /// Pagination cursor for fetching the next page. Null if no more results. Only present when count parameter is not 'true'.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Total count of matching logs. Only present when count parameter is 'true'. When this is returned, data and cursor are not included.
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; set; }

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
