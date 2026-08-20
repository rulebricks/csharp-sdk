using OneOf;

namespace RulebricksApi;

public partial interface IObjectsClient
{
    /// <summary>
    /// Lists the workspace's objects (JSON Schemas). The provided API key must have permission to view vocabulary values. Results are scoped to the API key holder's user groups.
    /// </summary>
    WithRawResponseTask<IEnumerable<WorkspaceObject>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates an object by ID or name and syncs enum values it generates. `content` and at least one of `id` or `name` are required. Objects help workspace admins programmatically determine multiple collections of values based on Rulebricks' contracts with external systems from a single JSON Schema source. Renaming the object's display name does not move its managed collection paths: those paths derive from schema field keys. When a schema field key itself is renamed, `field_rename` can preserve the generated values' identities.
    /// </summary>
    WithRawResponseTask<UpsertObjectResponse> UpsertAsync(
        OneOf<object> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetches one object by ID or exact name. The provided API key must have permission to view vocabulary values.
    /// </summary>
    WithRawResponseTask<WorkspaceObject> GetAsync(
        GetObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the object. By default, unused values are permanently deleted while values referenced by draft, current, or historical rules, flows, or other vocabulary values are archived. Pass values=detach to keep every generated value active as an ordinary, hand-editable value.
    /// </summary>
    WithRawResponseTask<DeleteObjectResponse> DeleteAsync(
        DeleteObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
