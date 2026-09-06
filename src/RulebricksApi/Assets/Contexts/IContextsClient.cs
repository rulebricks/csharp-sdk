using OneOf;
using RulebricksApi;
using RulebricksApi.Assets.Contexts;

namespace RulebricksApi.Assets;

public partial interface IContextsClient
{
    public IRelationshipsClient Relationships { get; }

    /// <summary>
    /// List contexts accessible to the API key. Filter by context name, folder name/ID, or an accessible user group's name/ID. Returns an array when pagination is omitted; optional limit/cursor pagination returns {data,cursor} in descending creation time and ID order.
    /// </summary>
    WithRawResponseTask<OneOf<IEnumerable<ContextListItem>, ContextListPage>> ListAsync(
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
