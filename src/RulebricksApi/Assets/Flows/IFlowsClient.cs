using RulebricksApi;

namespace RulebricksApi.Assets;

public partial interface IFlowsClient
{
    /// <summary>
    /// List all flows in the organization.
    /// </summary>
    WithRawResponseTask<IEnumerable<FlowDetail>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
