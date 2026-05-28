using OneOf;
using RulebricksApi.Assets;

namespace RulebricksApi;

public partial interface IAssetsClient
{
    public RulebricksApi.Assets.IRulesClient Rules { get; }
    public RulebricksApi.Assets.IFlowsClient Flows { get; }
    public IFoldersClient Folders { get; }

    /// <summary>
    /// Get the rule execution usage of your organization.
    /// </summary>
    WithRawResponseTask<UsageStatistics> GetUsageAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Import rules, flows, contexts, and values from an Rulebricks manifest file (*.rbm).
    /// </summary>
    WithRawResponseTask<ImportManifestResponse> ImportRbmAsync(
        ImportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export selected rules, flows, contexts, and values to an Rulebricks manifest file (*.rbm).
    /// </summary>
    WithRawResponseTask<
        OneOf<ExportManifestResponse, ExportManifestPreviewResponse>
    > ExportRbmAsync(
        ExportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
