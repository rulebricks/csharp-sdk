using RulebricksApi.Contexts;

namespace RulebricksApi;

public partial interface IContextsClient
{
    public RulebricksApi.Contexts.IObjectsClient Objects { get; }
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
    /// Re-evaluate registered pending rule and flow executions for this instance after their fact or relationship dependencies may have become available. This does not run every bound asset.
    /// </summary>
    WithRawResponseTask<CascadeContextResponse> CascadeAsync(
        CascadeContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit an array of records to any context in one synchronous call. Records merge into their context instances (matched by the context's identity fact), bound rules and flows whose inputs became satisfied execute, and the response returns the resolved state of every touched instance. Retries are always safe: merges are idempotent and executions are deduplicated by input hash. Fact history is recorded for tracked facts exactly as on individual writes. Clients chunk large datasets across requests.
    /// </summary>
    WithRawResponseTask<ContextBatchResponse> BulkIngestAsync(
        BulkIngestContextsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
