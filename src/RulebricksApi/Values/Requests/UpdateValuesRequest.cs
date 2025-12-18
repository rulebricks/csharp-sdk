using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record UpdateValuesRequest
{
    /// <summary>
    /// A dictionary of keys and values to update or add. Supports both flat key-value pairs and nested objects. Nested objects will be automatically flattened using dot notation with readable key names (e.g., 'user.contact_info.email' becomes 'User.Contact Info.Email').
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, object?> Values { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Optional array of access group names or IDs. If omitted and user belongs to access groups, values will be assigned to all user's access groups. Required if values should be restricted to specific access groups.
    /// </summary>
    [JsonPropertyName("accessGroups")]
    public IEnumerable<string>? AccessGroups { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
