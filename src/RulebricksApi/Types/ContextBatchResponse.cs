using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Response from a context batch: admission counts, per-record rejections, execution outcomes, and the resolved state of every touched instance.
/// </summary>
[Serializable]
public record ContextBatchResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The context slug.
    /// </summary>
    [JsonPropertyName("context")]
    public string? Context { get; set; }

    /// <summary>
    /// Trace ID for the batch request (join key into decision logs when tracing is enabled; always null on the cloud platform).
    /// </summary>
    [JsonPropertyName("trace_id")]
    public string? TraceId { get; set; }

    /// <summary>
    /// Number of distinct instances written (duplicate identities within the batch fold into one).
    /// </summary>
    [JsonPropertyName("accepted")]
    public int? Accepted { get; set; }

    /// <summary>
    /// Number of records rejected by validation.
    /// </summary>
    [JsonPropertyName("rejected")]
    public int? Rejected { get; set; }

    /// <summary>
    /// Number of successful bound-asset executions.
    /// </summary>
    [JsonPropertyName("executed")]
    public int? Executed { get; set; }

    /// <summary>
    /// Present when data was committed but execution could not run or complete (e.g. queue processing unavailable). Retrying the same chunk once healthy converges.
    /// </summary>
    [JsonPropertyName("execution_degraded")]
    public string? ExecutionDegraded { get; set; }

    /// <summary>
    /// Present when the batch re-evaluated dependent contexts through relationships (one level). Dependents with auto-execution disabled run only previously registered pending work. Each entry summarizes one dependent context's re-evaluation.
    /// </summary>
    [JsonPropertyName("cascaded")]
    public IEnumerable<ContextCascadeSummary>? Cascaded { get; set; }

    [JsonPropertyName("timings")]
    public ContextBatchResponseTimings? Timings { get; set; }

    /// <summary>
    /// Per-record validation failures, referencing positions in the submitted array.
    /// </summary>
    [JsonPropertyName("rejections")]
    public IEnumerable<ContextBatchResponseRejectionsItem>? Rejections { get; set; }

    /// <summary>
    /// One entry per touched instance. Fields beyond instance_id can be narrowed with the include query parameter.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<ContextBatchResponseResultsItem>? Results { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
