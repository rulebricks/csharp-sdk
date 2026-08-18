using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record DynamicValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the vocabulary value.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Name of the vocabulary value (may include dot notation for nested properties).
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Type identifier for the value (e.g., 'string', 'number', 'boolean', 'list', 'function', etc.)
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// The actual value - can be any valid JSON type. Materialized by default when the payload contains value-to-value references; with resolve=false the stored payload is returned as-is, with ValueReference markers intact.
    /// </summary>
    [JsonPropertyName("value")]
    public OneOf<
        string,
        double,
        bool,
        IEnumerable<object>,
        Dictionary<string, object?>
    >? Value { get; set; }

    /// <summary>
    /// Rules that use this vocabulary value (only included when 'include=usage' parameter is used).
    /// </summary>
    [JsonPropertyName("usages")]
    public IEnumerable<RuleUsage>? Usages { get; set; }

    /// <summary>
    /// User groups assigned to this value.
    /// </summary>
    [JsonPropertyName("user_groups")]
    public IEnumerable<string>? UserGroups { get; set; }

    /// <summary>
    /// Arbitrary metadata attached to this value (set via metadata_by_name on writes). System-managed values carry provenance here (e.g. the object that generated them).
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

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
