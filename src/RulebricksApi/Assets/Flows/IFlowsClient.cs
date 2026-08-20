using RulebricksApi;

namespace RulebricksApi.Assets;

public partial interface IFlowsClient
{
    /// <summary>
    /// List all flows in the organization. Results are scoped to the API key holder's user groups. Optionally filter by folder name or ID, labels, user group name or ID when the API key has access to that group, or by name.
    /// </summary>
    WithRawResponseTask<IEnumerable<FlowDetail>> ListAsync(
        ListFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or update a flow from the Rulebricks Flow Schema (a list of `nodes` and `connections`). The server expands the Rulebricks Flow Schema definition into the full flow graph - laying it out, wiring property/control handles, resolving referenced published rules, and backfilling node defaults - so the result both renders in the editor and executes via `/flows/{slug}` without any manual editing. If `id` is provided the matching flow is updated; otherwise a new flow is created (`id`/`slug` auto-generated). Flows auto-publish unless `_publish` is set to `false`.
    /// </summary>
    WithRawResponseTask<FlowImportResponse> PushAsync(
        ImportFlowRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Export a flow into the Rulebricks Flow Schema (nodes + connections), the same shape accepted by `/admin/flows/import`. Works for flows built entirely by hand in the editor, so they can be round-tripped or version-controlled. This is distinct from the top-level `/admin/export`, which produces `.rbm` manifests.
    /// </summary>
    WithRawResponseTask<FlowImportPayload> PullAsync(
        PullFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific flow by its ID.
    /// </summary>
    WithRawResponseTask<SuccessMessage> DeleteAsync(
        DeleteFlowRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
