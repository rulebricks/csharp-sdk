using RulebricksApi;

namespace RulebricksApi.Users;

public partial interface IGroupsClient
{
    /// <summary>
    /// List all user groups available in your Rulebricks organization.
    /// </summary>
    WithRawResponseTask<IEnumerable<UserGroup>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new user group in your Rulebricks organization.
    /// </summary>
    WithRawResponseTask<UserGroup> CreateAsync(
        CreateUserGroupRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
