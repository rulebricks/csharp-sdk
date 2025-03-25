using System.Text.Json.Serialization;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

public record UpdateValuesRequest
{
    /// <summary>
    /// A flat dictionary of keys and values to update or add.
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<
        string,
        OneOf<string, double, bool, IEnumerable<string>>
    > Values { get; set; } =
        new Dictionary<string, OneOf<string, double, bool, IEnumerable<string>>>();

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
