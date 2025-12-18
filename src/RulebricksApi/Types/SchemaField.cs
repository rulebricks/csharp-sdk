using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record SchemaField : IJsonOnDeserialized
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
    /// Whether this field is visible in the UI.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; set; }

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
    /// Data type of this field.
    /// </summary>
    [JsonPropertyName("type")]
    public SchemaFieldType? Type { get; set; }

    /// <summary>
    /// Default value for this field.
    /// </summary>
    [JsonPropertyName("defaultValue")]
    public OneOf<
        string,
        double,
        bool,
        Dictionary<string, object?>,
        IEnumerable<object>
    >? DefaultValue { get; set; }

    /// <summary>
    /// Computed default value for this field.
    /// </summary>
    [JsonPropertyName("defaultComputedValue")]
    public string? DefaultComputedValue { get; set; }

    /// <summary>
    /// Transformation expression to apply to this field.
    /// </summary>
    [JsonPropertyName("transform")]
    public string? Transform { get; set; }

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
