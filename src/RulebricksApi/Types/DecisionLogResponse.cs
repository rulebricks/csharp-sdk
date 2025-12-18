using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Response containing decision logs or a count.
/// </summary>
[Serializable]
public record DecisionLogResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of decision log entries (omitted when count=true).
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<DecisionLog>? Data { get; set; }

    /// <summary>
    /// Pagination cursor for fetching the next page. Null if no more results.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Total count of matching logs (only present when count=true parameter is used).
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
