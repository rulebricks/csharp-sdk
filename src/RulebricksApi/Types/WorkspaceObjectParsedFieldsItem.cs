using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record WorkspaceObjectParsedFieldsItem : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Rule-facing field key. Array-item fields use a key relative to their scope and never include [] notation.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    /// <summary>
    /// Containing array path for a derived item field. Omitted for root fields.
    /// </summary>
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    /// <summary>
    /// Source-schema path used for editing and enum collection derivation; may include [] markers.
    /// </summary>
    [JsonPropertyName("schemaPath")]
    public string? SchemaPath { get; set; }

    /// <summary>
    /// Display-only, fully qualified label for an array-item scope, including the stored object name and every nesting level (for example, 'Inventory Warehouses Cars'). It does not identify a stored object or control managed collection paths; those derive from schema field keys/schemaPath.
    /// </summary>
    [JsonPropertyName("derivedObjectName")]
    public string? DerivedObjectName { get; set; }

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
