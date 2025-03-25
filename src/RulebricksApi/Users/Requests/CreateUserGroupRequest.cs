using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record CreateUserGroupRequest
{
    /// <summary>
    /// Unique name of the user group.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Description of the user group.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
