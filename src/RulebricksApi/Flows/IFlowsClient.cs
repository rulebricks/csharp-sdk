using OneOf;

namespace RulebricksApi;

public partial interface IFlowsClient
{
    /// <summary>
    /// Execute a flow by slug and optional version. Policy failures return `{ error }` with status 200, including per-item errors for bulk requests. Errors: 400 invalid input, 500 unhandled execution failure, 503 unavailable, 504 timeout.
    /// </summary>
    WithRawResponseTask<
        OneOf<Dictionary<string, object?>, IEnumerable<Dictionary<string, object?>>>
    > ExecuteAsync(
        ExecuteFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
