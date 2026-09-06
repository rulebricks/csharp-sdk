using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// HTTP 202: required facts are missing. The registered rule/flow runs when those facts arrive and remains visible under `/pending` until then.
/// </summary>
[Serializable]
public record PendingContextEvaluationResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Always 'pending'.
    /// </summary>
    [JsonPropertyName("status")]
    public required PendingContextEvaluationResponseStatus Status { get; set; }

    /// <summary>
    /// Combined identifier in format 'contextSlug:instanceId'.
    /// </summary>
    [JsonPropertyName("context")]
    public required string Context { get; set; }

    /// <summary>
    /// The slug of the rule awaiting execution (rule solves only).
    /// </summary>
    [JsonPropertyName("rule")]
    public string? Rule { get; set; }

    /// <summary>
    /// The slug of the flow awaiting execution (flow executions only).
    /// </summary>
    [JsonPropertyName("flow")]
    public string? Flow { get; set; }

    /// <summary>
    /// Fact keys currently present on the instance.
    /// </summary>
    [JsonPropertyName("have")]
    public IEnumerable<string>? Have { get; set; }

    /// <summary>
    /// Fact keys still required before execution.
    /// </summary>
    [JsonPropertyName("need")]
    public IEnumerable<string>? Need { get; set; }

    /// <summary>
    /// What the evaluation is waiting for: entries carry either a context/instance/fields triple for missing facts, or a relation name for pending related data.
    /// </summary>
    [JsonPropertyName("waiting_on")]
    public IEnumerable<ContextWaitingOn>? WaitingOn { get; set; }

    /// <summary>
    /// When the pending registration expires (the context's TTL from now).
    /// </summary>
    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

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
