using System.Text.Json;
using System.Text.Json.Serialization;
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
    /// Data type of this field. 'function' type fields compute values dynamically.
    /// </summary>
    [JsonPropertyName("type")]
    public ContextSchemaFieldType? Type { get; set; }

    /// <summary>
    /// Default value for this field.
    /// </summary>
    [JsonPropertyName("defaultValue")]
    public object? DefaultValue { get; set; }

    /// <summary>
    /// Whether this field is derived from rule/flow outputs.
    /// </summary>
    [JsonPropertyName("derived")]
    public bool? Derived { get; set; }

    /// <summary>
    /// The rule ID that derives this field (if derived).
    /// </summary>
    [JsonPropertyName("sourceRule")]
    public string? SourceRule { get; set; }

    /// <summary>
    /// The flow ID that derives this field (if derived).
    /// </summary>
    [JsonPropertyName("sourceFlow")]
    public string? SourceFlow { get; set; }

    /// <summary>
    /// The source field key in the rule/flow output.
    /// </summary>
    [JsonPropertyName("sourceField")]
    public string? SourceField { get; set; }

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
