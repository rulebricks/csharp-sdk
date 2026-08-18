namespace RulebricksApi;

public partial interface IFlowsClient
{
    /// <summary>
    /// Execute a flow by its slug. Optionally target a specific published version (e.g. `3`) or a release environment (e.g. `production`) via the `version` path segment; `latest` (the default) executes the current published version.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> ExecuteAsync(
        ExecuteFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
