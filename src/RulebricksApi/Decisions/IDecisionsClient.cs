namespace RulebricksApi;

public partial interface IDecisionsClient
{
    /// <summary>
    /// Query decision logs with support for the decision data query language, rule/status filters, date ranges, and pagination. The query language supports field comparisons (e.g., `alpha=0`, `score&gt;10`), contains/not-contains (e.g., `name:John`, `status!:error`), boolean logic (`AND`, `OR`), and parentheses for grouping.
    /// </summary>
    WithRawResponseTask<DecisionLogResponse> QueryAsync(
        QueryDecisionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
