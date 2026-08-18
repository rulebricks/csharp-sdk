using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Paginated values envelope, returned when 'limit' or 'cursor' is provided. Ordered by name.
/// </summary>
[Serializable]
public record DynamicValuePage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("data")]
    public IEnumerable<DynamicValue> Data { get; set; } = new List<DynamicValue>();

    /// <summary>
    /// Cursor for the next page, or null when this is the last page.
    /// </summary>
    [JsonPropertyName("next_cursor")]
    public string? NextCursor { get; set; }

    /// <summary>
    /// Total number of matching values. Only included on the first page (no cursor).
    /// </summary>
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    /// <summary>
    /// Present and true when 'total' is a planner estimate rather than an exact count (large catalogs).
    /// </summary>
    [JsonPropertyName("total_is_estimate")]
    public bool? TotalIsEstimate { get; set; }

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
