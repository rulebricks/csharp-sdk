using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ListValuesRequest
{
    /// <summary>
    /// Query all vocabulary values containing a specific name
    /// </summary>
    [JsonIgnore]
    public string? Name { get; set; }

    /// <summary>
    /// Only return values whose name starts with this collection prefix (e.g. 'Countries.').
    /// </summary>
    [JsonIgnore]
    public string? Prefix { get; set; }

    /// <summary>
    /// Only return values of this type (string, number, boolean, list, date, function).
    /// </summary>
    [JsonIgnore]
    public string? Type { get; set; }

    /// <summary>
    /// Page size (default 100, max 1000). Providing limit or cursor switches the response to the paginated { data, next_cursor } envelope.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Opaque pagination cursor from a previous page's next_cursor.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Filter results by user group name or ID. The value is validated against workspace groups. Admin/unrestricted API keys can request any group-specific view; restricted API keys may only filter to one of their assigned groups and receive a 403 when filtering outside those groups.
    /// </summary>
    [JsonIgnore]
    public string? UserGroup { get; set; }

    /// <summary>
    /// Comma-separated list of additional data to include. Use 'usage' to include which rules reference each value.
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    /// <summary>
    /// By default, payloads containing value-to-value references are returned materialized (references replaced with their resolved values). Pass 'false' to return stored payloads as-is, with { "$rb": "globalValue", "id": "..." } reference markers intact, so the reference graph round-trips.
    /// </summary>
    [JsonIgnore]
    public bool? Resolve { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
