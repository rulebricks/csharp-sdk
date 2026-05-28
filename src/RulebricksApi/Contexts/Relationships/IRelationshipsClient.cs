using RulebricksApi;

namespace RulebricksApi.Contexts;

public partial interface IRelationshipsClient
{
    /// <summary>
    /// List all relationships for a specific context.
    /// </summary>
    WithRawResponseTask<ContextRelationshipsResponse> ListAsync(
        ListRelationshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new relationship between two contexts.
    /// </summary>
    WithRawResponseTask<ContextRelationshipOutgoing> CreateAsync(
        CreateRelationshipRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific relationship between contexts.
    /// </summary>
    WithRawResponseTask<DeleteRelationshipResponse> DeleteAsync(
        DeleteRelationshipsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
