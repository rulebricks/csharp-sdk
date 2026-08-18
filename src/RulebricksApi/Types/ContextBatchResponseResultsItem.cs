using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ContextBatchResponseResultsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("instance_id")]
    public string? InstanceId { get; set; }

    /// <summary>
    /// Positions in the submitted array that folded into this instance.
    /// </summary>
    [JsonPropertyName("positions")]
    public IEnumerable<int>? Positions { get; set; }

    [JsonPropertyName("is_new")]
    public bool? IsNew { get; set; }

    [JsonPropertyName("status")]
    public ContextBatchResponseResultsItemStatus? Status { get; set; }

    [JsonPropertyName("have")]
    public IEnumerable<string>? Have { get; set; }

    [JsonPropertyName("need")]
    public IEnumerable<string>? Need { get; set; }

    /// <summary>
    /// Resolved instance state after merging and any executions, including computed facts.
    /// </summary>
    [JsonPropertyName("state")]
    public Dictionary<string, object?>? State { get; set; }

    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Per-asset record of the last run: input hash, status, timestamp, trace IDs, error.
    /// </summary>
    [JsonPropertyName("executions")]
    public Dictionary<string, object?>? Executions { get; set; }

    /// <summary>
    /// Assets evaluated for this instance in this request.
    /// </summary>
    [JsonPropertyName("executed")]
    public IEnumerable<ContextBatchResponseResultsItemExecutedItem>? Executed { get; set; }

    /// <summary>
    /// True when at least one bound asset was considered for this instance - including assets that settled as skipped_already_run. False (with a reason) when nothing was attempted.
    /// </summary>
    [JsonPropertyName("triggered")]
    public bool? Triggered { get; set; }

    /// <summary>
    /// Present when triggered is false (executed is empty): not_ready = required facts still missing; inputs_unchanged = the instance is complete but no bound asset had satisfiable inputs to attempt; no_bound_assets = the context has no published bound rules or flows; auto_execute_disabled = the context's auto_execute_decisions is off; execution_unavailable = the execution backend was unreachable. Note: assets whose inputs are unchanged since their last successful run appear as executed entries with status skipped_already_run and leave triggered true.
    /// </summary>
    [JsonPropertyName("reason")]
    public ContextBatchResponseResultsItemReason? Reason { get; set; }

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
