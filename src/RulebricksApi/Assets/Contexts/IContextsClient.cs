using RulebricksApi;
using RulebricksApi.Assets.Contexts;

namespace RulebricksApi.Assets;

public partial interface IContextsClient
{
    public IRelationshipsClient Relationships { get; }

    /// <summary>
    /// Retrieve all contexts for the authenticated user. Results are scoped to the API key holder's user groups. Optionally filter by folder name or ID, by user group name or ID when the API key has access to that group, or by name.
    /// </summary>
    WithRawResponseTask<IEnumerable<ContextListItem>> ListAsync(
        ListContextsRequest request,
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
        GetContextsRequest request,
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
        DeleteContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
