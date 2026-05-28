using RulebricksApi;

namespace RulebricksApi.Contexts;

public partial interface IObjectsClient
{
    /// <summary>
    /// Retrieve all contexts for the authenticated user.
    /// </summary>
    WithRawResponseTask<IEnumerable<ContextListItem>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new context for the authenticated user.
    /// </summary>
    WithRawResponseTask<ContextDetail> CreateAsync(
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
