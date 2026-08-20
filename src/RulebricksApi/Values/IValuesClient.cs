using OneOf;

namespace RulebricksApi;

public partial interface IValuesClient
{
    /// <summary>
    /// Retrieve vocabulary values for the authenticated user. Results are scoped to the API key holder's user groups. Optionally filter by user group name or ID when the API key has access to that group. Use the 'include' parameter to control whether usage information is returned. Small workspaces may omit pagination to receive the full catalog as an array (legacy behavior); workspaces above the catalog threshold must paginate with 'limit'/'cursor', which returns { data, next_cursor, total? } ordered by name. The 'prefix' and 'type' filters narrow results to a collection or value type.
    /// </summary>
    WithRawResponseTask<OneOf<IEnumerable<DynamicValue>, DynamicValuePage>> ListAsync(
        ListValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update existing vocabulary values or add new ones for the authenticated user. Supports both flat and nested object structures.
    /// </summary>
    WithRawResponseTask<OneOf<IEnumerable<DynamicValue>, UpdateValuesSummaryResponse>> UpdateAsync(
        UpdateValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific vocabulary value for the authenticated user by its ID. Deletion is blocked while the value is referenced by any rule or flow. Values whose entire payload references the deleted value are deleted with it (cascade), and list values referencing it lose the referencing items; both effects are reported in the response.
    /// </summary>
    WithRawResponseTask<DeleteValueResponse> DeleteAsync(
        DeleteValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Declaratively makes a collection exactly equal to the payload. Values in the payload are upserted (Existing values keep their IDs), and values under the collection that are absent from the payload are archived by default. The `sync` endpoint supports uploading a particularly large amount of values (100k+) in chunks, using the `sync_id` parameter to track the run.
    /// </summary>
    WithRawResponseTask<SyncValuesResponse> SyncAsync(
        SyncValuesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
