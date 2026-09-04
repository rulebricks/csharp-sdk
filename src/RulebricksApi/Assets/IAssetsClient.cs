using OneOf;
using RulebricksApi.Assets;

namespace RulebricksApi;

public partial interface IAssetsClient
{
    public RulebricksApi.Assets.IRulesClient Rules { get; }
    public RulebricksApi.Assets.IFlowsClient Flows { get; }
    public IFoldersClient Folders { get; }
    public RulebricksApi.Assets.IContextsClient Contexts { get; }

    /// <summary>
    /// Get the rule execution usage of your organization.
    /// </summary>
    WithRawResponseTask<UsageStatistics> GetUsageAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Import rules, flows, contexts, and values from a Rulebricks manifest file (*.rbm). Plain JSON remains supported, and clients may send the same JSON envelope gzip-compressed with `Content-Type: application/octet-stream` and `X-Rulebricks-Content-Encoding: gzip`.
    /// </summary>
    WithRawResponseTask<
        OneOf<ImportManifestResponse, ImportManifestPreviewResponse>
    > ImportRbmAsync(
        Stream request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export selected rules, flows, contexts, and values to a Rulebricks manifest file (*.rbm). Dependencies are resolved automatically: exporting a flow includes its rules, contexts, vocabulary values, and any flows referenced by Run Flow nodes (recursively). Set `compress: true` to receive the manifest in compressed form (a compress-json array). Set `download: true` to receive that manifest directly as a streamed attachment instead of inside the `{ success, manifest }` envelope.
    /// </summary>
    WithRawResponseTask<
        OneOf<ExportManifestResponse, ExportManifestPreviewResponse>
    > ExportRbmAsync(
        ExportManifestRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
