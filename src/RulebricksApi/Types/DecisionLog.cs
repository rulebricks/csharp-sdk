using global::System.Text.Json.Serialization;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Rule/flow execution log entry with request, response, and decision details.
/// </summary>
[Serializable]
public record DecisionLog : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// When the rule/flow was executed.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    /// <summary>
    /// Name of the rule or flow that was executed.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// API endpoint that was called.
    /// </summary>
    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    /// <summary>
    /// HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// The request payload sent to the rule/flow. Can be an object for single requests or an array for bulk operations.
    /// </summary>
    [JsonPropertyName("request")]
    public OneOf<
        Dictionary<string, object?>,
        IEnumerable<Dictionary<string, object?>>
    >? Request { get; set; }

    /// <summary>
    /// The response payload returned by the rule/flow. Can be an object for single responses or an array for bulk operations.
    /// </summary>
    [JsonPropertyName("response")]
    public DecisionLogResponse? Response { get; set; }

    /// <summary>
    /// Decision details including matched conditions, rows, and evaluation metadata. API-owned metadata keys are normalized to snake_case where known, including rule, flow, context, item, and correlation fields such as `rule_id`, `flow_execution_id`, `root_flow_execution_id`, `parallel_execution_id`, `context_instance_id`, `item_indexes`, and `item_execution_ids` (bulk flow runs' per-item execution ids, aligned 1:1 with the request array). Rule decisions also expose the bounded execution-time vocabulary snapshot under `referenced_values`; `referenced_values_truncated` indicates that one or more payloads or entries were omitted. Executions backed by a frozen published vocabulary include its asset/version pointer under `value_world`. User-defined request/response schema keys are preserved.
    /// </summary>
    [JsonPropertyName("decision")]
    public Dictionary<string, object?>? Decision { get; set; }

    /// <summary>
    /// Observability (OpenTelemetry) trace ID for this execution. Populated on self-hosted deployments only; always null on cloud.
    /// </summary>
    [JsonPropertyName("trace_id")]
    public string? TraceId { get; set; }

    /// <summary>
    /// Decompressed execution path trace for flow records: the executed steps with their inputs and outputs. An object for single flow runs, or a null-aligned array (1:1 with the request array) for bulk runs. Only present when `include_traces=true`; null for non-flow records, runs without a stored trace, and traces dropped by the size cap (see the decision's `path_trace_omitted`).
    /// </summary>
    [JsonPropertyName("path_trace")]
    public OneOf<
        Dictionary<string, object?>,
        IEnumerable<Dictionary<string, object?>?>
    >? PathTrace { get; set; }

    /// <summary>
    /// Only present when `item_filter` was supplied and this record is bulk-shaped: the original zero-based positions (within this record's stored request array) of the items that matched the filter, in order. The record's `request`, `response`, and index-aligned decision fields are sliced to these items; `decision.item_count` keeps the original total. Empty when no items matched. On self-hosted deployments where large bulk runs are logged in chunks, the absolute position within the original API call is `decision.logChunk.offset` plus this value.
    /// </summary>
    [JsonPropertyName("matched_items")]
    public IEnumerable<int>? MatchedItems { get; set; }

    /// <summary>
    /// Error message if the execution failed.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// Whether the request/response data was truncated due to size limits or unavailable payload columns. Responses carry full payloads whenever they were stored.
    /// </summary>
    [JsonPropertyName("abbreviated")]
    public bool? Abbreviated { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
