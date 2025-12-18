using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record UserInviteRequest
{
    /// <summary>
    /// Email of the user to invite.
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <summary>
    /// System or custom role ID to assign to the user. Available system roles include 'admin', 'editor', and 'developer'.
    /// </summary>
    [JsonPropertyName("role")]
    public UserInviteRequestRole? Role { get; set; }

    /// <summary>
    /// List of access group names or IDs to assign to the user. All specified groups must exist in your organization.
    /// </summary>
    [JsonPropertyName("accessGroups")]
    public IEnumerable<string>? AccessGroups { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
