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
    /// Import rules, flows, contexts, and values from an Rulebricks manifest file (*.rbm). Both plain manifests and compressed ones (the compress-json array form produced by exporting with `compress: true`) are accepted and detected automatically. Run Flow (subflow) references between flows in the manifest are resolved to the slugs, IDs, and published versions the flows receive in this workspace.
    /// </summary>
    WithRawResponseTask<ImportManifestResponse> ImportRbmAsync(
        ImportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export selected rules, flows, contexts, and values to an Rulebricks manifest file (*.rbm). Dependencies are resolved automatically: exporting a flow includes its rules, contexts, vocabulary values, and any flows referenced by Run Flow nodes (recursively). Set `compress: true` to receive the manifest in compressed form (a compress-json array), which is much smaller and can be saved directly as a .rbm file; the import endpoint accepts both forms.
    /// </summary>
    WithRawResponseTask<
        OneOf<ExportManifestResponse, ExportManifestPreviewResponse>
    > ExportRbmAsync(
        ExportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
