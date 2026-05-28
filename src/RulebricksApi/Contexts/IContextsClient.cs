using RulebricksApi.Contexts;

namespace RulebricksApi;

public partial interface IContextsClient
{
    public IObjectsClient Objects { get; }
    public IRelationshipsClient Relationships { get; }

    /// <summary>
    /// Retrieve the current state of a context instance.
    /// </summary>
    WithRawResponseTask<ContextInstanceState> GetAsync(
        GetContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit data to a context instance, creating it if it doesn't exist. May trigger bound rule/flow evaluations.
    /// </summary>
    WithRawResponseTask<SubmitContextDataResponse> SubmitAsync(
        SubmitContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a specific context instance and its history.
    /// </summary>
    WithRawResponseTask<DeleteContextInstanceResponse> DeleteAsync(
        DeleteContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the change history for a context instance.
    /// </summary>
    WithRawResponseTask<ContextInstanceHistory> GetHistoryAsync(
        GetHistoryContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get list of rules/flows that need to be evaluated for this instance.
    /// </summary>
    WithRawResponseTask<ContextInstancePendingResponse> GetPendingAsync(
        GetPendingContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Execute a specific rule using the context instance's state as input.
    /// </summary>
    WithRawResponseTask<SolveContextRuleResponse> SolveAsync(
        SolveContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Trigger re-evaluation of all bound rules and flows for the instance.
    /// </summary>
    WithRawResponseTask<CascadeContextResponse> CascadeAsync(
        CascadeContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Execute a specific flow using the context instance's state as input.
    /// </summary>
    WithRawResponseTask<SolveContextFlowResponse> ExecuteAsync(
        ExecuteContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
