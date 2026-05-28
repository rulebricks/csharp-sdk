namespace RulebricksApi;

public partial interface IFlowsClient
{
    /// <summary>
    /// Execute a flow by its slug.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExecuteAsync(
        ExecuteFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
