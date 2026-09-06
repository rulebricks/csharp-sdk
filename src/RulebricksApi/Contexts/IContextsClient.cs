namespace RulebricksApi;

public partial interface IContextsClient
{
    /// <summary>
    /// Retrieve the current state of a context instance.
    /// </summary>
    WithRawResponseTask<ContextInstanceState> GetAsync(
        GetContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit data to a context instance, creating it if it doesn't exist. May trigger bound rule/flow evaluations. Each instance supports up to 64 MiB of combined stored state and execution metadata, measured as serialized database JSON. Deployment transport limits and execution deadlines also apply.
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
    /// Re-evaluate registered pending rule and flow executions for this instance after their fact or relationship dependencies may have become available. This does not run every bound asset.
    /// </summary>
    WithRawResponseTask<CascadeContextResponse> CascadeAsync(
        CascadeContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Execute one rule bound to this context. An optional object body is validated and persisted before evaluation. Returns HTTP 202 and registers pending work when that rule's own inputs are not yet available.
    /// </summary>
    WithRawResponseTask<SolveContextRuleResponse> SolveRuleAsync(
        SolveRuleContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Execute one flow bound to this context. An optional object body is validated and persisted before evaluation. Returns HTTP 202 and registers pending work when that flow's own inputs are not yet available.
    /// </summary>
    WithRawResponseTask<SolveContextFlowResponse> SolveFlowAsync(
        SolveFlowContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Synchronously merge records by identity, record tracked history, and execute ready bound rules/flows. Returns each touched instance's resolved state and execution summary. Successful runs are deduplicated by input hash; lost responses can cause repeated external effects. Each instance supports up to 64 MiB of combined stored state and execution metadata, measured as serialized database JSON. Contexts impose no separate request-wide size or record-count budget. Deployment transport limits, available resources, and execution deadlines still apply. Error responses identify committed and failed instances when known; a failed request does not imply rollback of earlier writes.
    /// </summary>
    WithRawResponseTask<ContextBatchResponse> BulkIngestAsync(
        BulkIngestContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
