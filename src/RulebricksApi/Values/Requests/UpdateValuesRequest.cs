using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record UpdateValuesRequest
{
    /// <summary>
    /// A dictionary of keys and values to update or add. Supports both flat key-value pairs and nested objects. Nested objects are automatically flattened using dot notation with keys preserved exactly as sent (e.g. 'user.contact_info.email' stays 'user.contact_info.email'). Individual payloads may be value-to-value references (see ValueReference): a scalar payload may be a single { "$ref": "<value name="">" } marker, and list payloads may mix literal items with reference markers.</value>
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, object?> Values { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Optional array of user group names or IDs. If omitted and user belongs to user groups, values will be assigned to all user's user groups. Required if values should be restricted to specific user groups.
    /// </summary>
    [JsonPropertyName("user_groups")]
    public IEnumerable<string>? UserGroups { get; set; }

    /// <summary>
    /// Optional metadata keyed by vocabulary value name. This is the canonical snake_case field; legacy clients may still send `metadataByName`. System-owned keys (managedBy, source, lockedReason, previousTokens, and archive/tombstone fields) are stripped from user payloads - managed provenance and archive state cannot be forged.
    /// </summary>
    [JsonPropertyName("metadata_by_name")]
    public Dictionary<string, Dictionary<string, object?>>? MetadataByName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
