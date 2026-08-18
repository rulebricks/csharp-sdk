using RulebricksApi;

namespace RulebricksApi.Contexts;

public partial interface IObjectsClient
{
    /// <summary>
    /// Retrieve all contexts for the authenticated user. Results are scoped to the API key holder's user groups. Optionally filter by folder name or ID, by user group name or ID when the API key has access to that group, or by name.
    /// </summary>
    WithRawResponseTask<IEnumerable<ContextListItem>> ListAsync(
        ListObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new context for the authenticated user.
    /// </summary>
    WithRawResponseTask<CreateContextResponse> CreateAsync(
        CreateContextRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific context by its ID.
    /// </summary>
    WithRawResponseTask<ContextDetail> GetAsync(
        GetObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing context's properties and schema.
    /// </summary>
    WithRawResponseTask<UpdateContextResponse> UpdateAsync(
        UpdateContextRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific context and all its instances.
    /// </summary>
    WithRawResponseTask<DeleteContextResponse> DeleteAsync(
        DeleteObjectsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
