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
    /// Update existing vocabulary values or add new ones for the authenticated user. Supports both flat and nested object structures. Nested objects are automatically flattened using dot notation with keys preserved exactly as sent (e.g. nested 'user_profile.first_name' becomes the value name 'user_profile.first_name'). Writes are set-based upserts keyed by value name - existing values keep their ids, so rule references stay valid - and each call is idempotent, so retrying a failed request is always safe. Imports of any size go through this endpoint (POST /values/bulk is an equivalent alias): drive large dictionaries as a sequence of chunked calls, each bounded by your deployment's request body limit. Payloads may compose values from other values with reference markers: { "$ref": "<value name="">" } references a value by name (existing values first, then values created by the same request), and { "$rb": "globalValue", "id": "<value id="">" } references by id. A scalar payload may be a single reference; list payloads may mix literal items and references. References are validated (existence, type match, cycles) before anything is written. Workspaces at or below the catalog threshold receive the full value list back (legacy behavior); larger workspaces receive summary counts ({ created, updated, processed }).</value></value>
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
