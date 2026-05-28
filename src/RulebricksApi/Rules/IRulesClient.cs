using OneOf;

namespace RulebricksApi;

public partial interface IRulesClient
{
    /// <summary>
    /// Executes a single rule identified by a unique slug. The request and response formats are dynamic, dependent on the rule configuration.
    /// </summary>
    WithRawResponseTask<Dictionary<string, object?>> SolveAsync(
        SolveRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Executes a particular rule against multiple request data payloads provided in a list.
    /// </summary>
    WithRawResponseTask<
        IEnumerable<OneOf<Dictionary<string, object?>, BulkRuleResponseItemError>>
    > BulkSolveAsync(
        BulkSolveRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Executes multiple rules or flows in parallel based on a provided mapping of rule/flow slugs to payloads.
    /// </summary>
    WithRawResponseTask<Dictionary<string, Dictionary<string, object?>>> ParallelSolveAsync(
        Dictionary<string, ParallelSolveRequestValue> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
