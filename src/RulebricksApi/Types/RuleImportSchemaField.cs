using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A request or response schema field used when importing a rule.
/// </summary>
[Serializable]
public record RuleImportSchemaField : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Unique key for this field.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Whether this field is shown in the editor table.
    /// </summary>
    [JsonPropertyName("show")]
    public required bool Show { get; set; }

    /// <summary>
    /// Display name for this field.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Optional field description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Data type for this field.
    /// </summary>
    [JsonPropertyName("type")]
    public required RuleImportSchemaFieldType Type { get; set; }

    /// <summary>
    /// Optional default value for this field.
    /// </summary>
    [JsonPropertyName("defaultValue")]
    public object? DefaultValue { get; set; }

    /// <summary>
    /// When true, this field should only accept values from a value collection.
    /// </summary>
    [JsonPropertyName("valuesOnly")]
    public bool? ValuesOnly { get; set; }

    /// <summary>
    /// Prefix used to scope available vocabulary values for this field.
    /// </summary>
    [JsonPropertyName("valuesPrefix")]
    public string? ValuesPrefix { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
