using RulebricksApi;

namespace RulebricksApi.Assets;

public partial interface IFoldersClient
{
    /// <summary>
    /// Retrieve all rule folders for the authenticated user.
    /// </summary>
    WithRawResponseTask<IEnumerable<Folder>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new rule folder or update an existing one for the authenticated user.
    /// </summary>
    WithRawResponseTask<Folder> UpsertAsync(
        UpsertFolderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific rule folder for the authenticated user. This does not delete the rules within the folder.
    /// </summary>
    WithRawResponseTask<Folder> DeleteAsync(
        DeleteFolderRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
