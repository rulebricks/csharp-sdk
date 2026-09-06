using OneOf;

namespace RulebricksApi;

public partial interface IFlowsClient
{
    /// <summary>
    /// Execute a flow by slug and optional version. The flow setting `failedResponseMode` controls execution-failure responses: a missing or invalid value is treated as `return` (the default), which returns an `{ "error": "..." }` payload with HTTP 200; `fail` returns HTTP 400 for input/schema failures and HTTP 500 for escalated policy/runtime failures. Request- and entity-level errors, capacity errors, and infrastructure failures remain non-2xx responses as documented.
    /// </summary>
    WithRawResponseTask<
        OneOf<
            OneOf<Dictionary<string, object?>, ExecutionErrorResult>,
            IEnumerable<OneOf<Dictionary<string, object?>, ExecutionErrorResult>>
        >
    > ExecuteAsync(
        ExecuteFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
