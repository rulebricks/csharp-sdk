using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A workspace object: a JSON Schema that is the source of truth for the system-managed vocabulary values generated from its enums.
/// </summary>
[Serializable]
public record WorkspaceObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the object.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Display name (unique in practice per workspace).
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The object's JSON Schema, as a string.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <summary>
    /// Detected content shape ('json_schema' or 'json_object').
    /// </summary>
    [JsonPropertyName("schema_type")]
    public string? SchemaType { get; set; }

    /// <summary>
    /// Original import format ('json', 'csv', or 'ddl').
    /// </summary>
    [JsonPropertyName("source_format")]
    public string? SourceFormat { get; set; }

    /// <summary>
    /// Flattened field descriptors derived from the schema.
    /// </summary>
    [JsonPropertyName("parsed_fields")]
    public IEnumerable<Dictionary<string, object?>>? ParsedFields { get; set; }

    /// <summary>
    /// User groups this object (and every value it generates) is visible to. Empty means workspace-wide.
    /// </summary>
    [JsonPropertyName("user_groups")]
    public IEnumerable<string>? UserGroups { get; set; }

    /// <summary>
    /// Present when the object is archived.
    /// </summary>
    [JsonPropertyName("archived_at")]
    public DateTime? ArchivedAt { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

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
