using RulebricksApi.Users;

namespace RulebricksApi;

public partial interface IUsersClient
{
    public IGroupsClient Groups { get; }

    /// <summary>
    /// Invite a new user to the organization or update role or user group data for an existing user.
    /// </summary>
    WithRawResponseTask<UserInviteResponse> InviteAsync(
        UserInviteRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all users (including the admin and all team members) in the organization with their details including email, name, API key, role, user groups, and join date.
    /// </summary>
    WithRawResponseTask<IEnumerable<UserDetail>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new user directly with a password, bypassing the email invitation flow. The user can immediately log in with the provided credentials.
    /// </summary>
    WithRawResponseTask<CreateUserResponse> CreateAsync(
        CreateUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
