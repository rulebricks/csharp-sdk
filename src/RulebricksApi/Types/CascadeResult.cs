using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Result of an auto-executed or cascaded rule/flow evaluation.
/// </summary>
[Serializable]
public record CascadeResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Combined identifier in format 'contextSlug:instanceId'.
    /// </summary>
    [JsonPropertyName("context")]
    public string? Context { get; set; }

    /// <summary>
    /// The rule slug (if this was a rule evaluation).
    /// </summary>
    [JsonPropertyName("rule")]
    public string? Rule { get; set; }

    /// <summary>
    /// The flow slug (if this was a flow evaluation).
    /// </summary>
    [JsonPropertyName("flow")]
    public string? Flow { get; set; }

    /// <summary>
    /// Whether the evaluation succeeded, failed, remains pending, or was skipped because the same inputs already completed successfully.
    /// </summary>
    [JsonPropertyName("status")]
    public CascadeResultStatus? Status { get; set; }

    /// <summary>
    /// The evaluation output.
    /// </summary>
    [JsonPropertyName("result")]
    public Dictionary<string, object?>? Result { get; set; }

    /// <summary>
    /// True for context auto-execution. Omitted for registered pending evaluations.
    /// </summary>
    [JsonPropertyName("auto_executed")]
    public bool? AutoExecuted { get; set; }

    /// <summary>
    /// List of field keys written back to the context (for rule evaluations).
    /// </summary>
    [JsonPropertyName("written_to_context")]
    public IEnumerable<string>? WrittenToContext { get; set; }

    /// <summary>
    /// Error message if the evaluation failed.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// True when execution stopped at a rate limit.
    /// </summary>
    [JsonPropertyName("rate_limited")]
    public bool? RateLimited { get; set; }

    /// <summary>
    /// True when execution stopped at a plan usage limit.
    /// </summary>
    [JsonPropertyName("usage_limited")]
    public bool? UsageLimited { get; set; }

    /// <summary>
    /// Dependencies still missing when the evaluation remains pending.
    /// </summary>
    [JsonPropertyName("need")]
    public IEnumerable<string>? Need { get; set; }

    /// <summary>
    /// Nested pending evaluations triggered by this rule's writeback.
    /// </summary>
    [JsonPropertyName("cascaded")]
    public IEnumerable<CascadeResult>? Cascaded { get; set; }

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
