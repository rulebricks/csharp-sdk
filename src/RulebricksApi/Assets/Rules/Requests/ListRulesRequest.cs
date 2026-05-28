using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[Serializable]
public record ListRulesRequest
{
    /// <summary>
    /// Filter rules by folder name or folder ID
    /// </summary>
    [JsonIgnore]
    public string? Folder { get; set; }

    /// <summary>
    /// Filter rules by user group name or ID. The value is validated against workspace groups. Admin/unrestricted API keys can request any group-specific view; restricted API keys may only filter to one of their assigned groups and receive a 403 when filtering outside those groups.
    /// </summary>
    [JsonIgnore]
    public string? UserGroup { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
