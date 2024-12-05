using System.Text.Json.Serialization;
using RulebricksApi;

#nullable enable

namespace RulebricksApi;

public record InviteRequest
{
    /// <summary>
    /// Email of the user to invite.
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; init; }

    /// <summary>
    /// Role to assign to the user.
    /// </summary>
    [JsonPropertyName("role")]
    public InviteRequestRole? Role { get; init; }

    /// <summary>
    /// List of access group names or IDs to assign to the user.
    /// </summary>
    [JsonPropertyName("accessGroups")]
    public IEnumerable<string>? AccessGroups { get; init; }
}
