namespace RulebricksApi;

public partial interface IObjectsClient
{
    /// <summary>
    /// Lists the workspace's objects (JSON Schemas). Results are scoped to the API key holder's user groups, matching the visibility model of values, rules, and flows: group-restricted keys only see objects whose user_groups overlap theirs.
    /// </summary>
    WithRawResponseTask<IEnumerable<WorkspaceObject>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates an object by ID or name and syncs enum values it generates. Objects help workspace admins programmatically determine multiple collections of values based on Rulebricks' contracts with external systems from a single JSON Schema source.
    /// </summary>
    WithRawResponseTask<UpsertObjectResponse> UpsertAsync(
        UpsertObjectRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches one object by ID or exact name.
    /// </summary>
    WithRawResponseTask<WorkspaceObject> GetAsync(
        GetObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the object. Its generated values always lose their management lock; by default they are also archived (published rules keep resolving them by id). Pass values=detach to keep them active as ordinary, hand-editable values instead. Requires the manage objects entitlement.
    /// </summary>
    WithRawResponseTask<DeleteObjectResponse> DeleteAsync(
        DeleteObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
