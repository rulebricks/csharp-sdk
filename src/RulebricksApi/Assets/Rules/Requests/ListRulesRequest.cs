using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[Serializable]
public record ListRulesRequest
{
    /// <summary>
    /// Filter by the exact rule or flow ID.
    /// </summary>
    [JsonIgnore]
    public string? Id { get; set; }

    /// <summary>
    /// Filter by the exact rule or flow slug (case-sensitive).
    /// </summary>
    [JsonIgnore]
    public string? Slug { get; set; }

    /// <summary>
    /// Match an exact ID or slug, or a case-insensitive substring of the name. Combined with all other filters.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <summary>
    /// Select a published version number (e.g. 3), release environment slug (e.g. production), or latest. Requires exactly one asset after all filters and permission checks. Multiple matches or an invalid version return 400; no match, an unpublished asset, or a missing version/release returns 404. The response is still a one-item array.
    /// </summary>
    [JsonIgnore]
    public string? Version { get; set; }

    /// <summary>
    /// Filter results by folder name or folder ID.
    /// </summary>
    [JsonIgnore]
    public string? Folder { get; set; }

    /// <summary>
    /// Filter results to assets containing all comma-separated labels.
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Labels { get; set; } = new List<string>();

    /// <summary>
    /// Filter results by user group name or ID. The value is validated against workspace groups. Admin/unrestricted API keys can request any group-specific view; restricted API keys may only filter to one of their assigned groups and receive a 403 when filtering outside those groups.
    /// </summary>
    [JsonIgnore]
    public string? UserGroup { get; set; }

    /// <summary>
    /// Filter results by name using a case-insensitive substring match.
    /// </summary>
    [JsonIgnore]
    public string? Name { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
