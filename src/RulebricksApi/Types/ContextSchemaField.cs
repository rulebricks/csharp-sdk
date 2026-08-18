using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A field definition within a context schema.
/// </summary>
[Serializable]
public record ContextSchemaField : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique key for this field.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// Display name for this field.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description of this field.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Data type of this field. `object` fields are parent nodes for dotted child facts; `function` fields are output-only.
    /// </summary>
    [JsonPropertyName("type")]
    public ContextSchemaFieldType? Type { get; set; }

    /// <summary>
    /// Default value for this field.
    /// </summary>
    [JsonPropertyName("default_value")]
    public object? DefaultValue { get; set; }

    /// <summary>
    /// Whether this base fact is required for overall context completeness.
    /// </summary>
    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    /// <summary>
    /// Whether external submissions are rejected for this base fact. Rule writebacks may still set it.
    /// </summary>
    [JsonPropertyName("output_only")]
    public bool? OutputOnly { get; set; }

    /// <summary>
    /// Whether changed values for this base fact are retained for history expressions and the history endpoint.
    /// </summary>
    [JsonPropertyName("track_history")]
    public bool? TrackHistory { get; set; }

    /// <summary>
    /// Whether values must come from the configured vocabulary collection.
    /// </summary>
    [JsonPropertyName("values_only")]
    public bool? ValuesOnly { get; set; }

    /// <summary>
    /// Vocabulary collection identifier, when configured.
    /// </summary>
    [JsonPropertyName("values_collection")]
    public string? ValuesCollection { get; set; }

    /// <summary>
    /// Required for derived facts: the expression evaluated from base, history, and relation values.
    /// </summary>
    [JsonPropertyName("expression")]
    public string? Expression { get; set; }

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
