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
    /// Per-asset last-run metadata: input hash, status, timestamp, trace IDs, execution_id for flows, error. Returned only when include contains executions.
    /// </summary>
    [JsonPropertyName("executions")]
    public Dictionary<string, object?>? Executions { get; set; }

    /// <summary>
    /// Assets evaluated for this instance in this request.
    /// </summary>
    [JsonPropertyName("executed")]
    public IEnumerable<ContextBatchResponseResultsItemExecutedItem>? Executed { get; set; }

    /// <summary>
    /// True when at least one bound asset was attempted for this instance. False, with a reason, when all assets were skipped or nothing was ready to run.
    /// </summary>
    [JsonPropertyName("triggered")]
    public bool? Triggered { get; set; }

    /// <summary>
    /// When triggered=false: not_ready (missing facts), inputs_unchanged (no ready asset needs rerunning), no_bound_assets (no published bindings), auto_execute_disabled (automatic execution off), execution_unavailable (backend unavailable), or execution_in_progress (ancestor flow running). Skipped entries may appear in executed.
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
