using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A pending rule or flow evaluation awaiting data.
/// </summary>
[Serializable]
public record ContextInstancePendingEvaluation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether this is a rule or flow evaluation.
    /// </summary>
    [JsonPropertyName("type")]
    public ContextInstancePendingEvaluationType? Type { get; set; }

    /// <summary>
    /// The rule slug (if type is 'rule').
    /// </summary>
    [JsonPropertyName("rule")]
    public string? Rule { get; set; }

    /// <summary>
    /// The rule ID (if type is 'rule').
    /// </summary>
    [JsonPropertyName("rule_id")]
    public string? RuleId { get; set; }

    /// <summary>
    /// The flow slug (if type is 'flow').
    /// </summary>
    [JsonPropertyName("flow")]
    public string? Flow { get; set; }

    /// <summary>
    /// The flow ID (if type is 'flow').
    /// </summary>
    [JsonPropertyName("flow_id")]
    public string? FlowId { get; set; }

    /// <summary>
    /// List of field keys or dependency objects this evaluation is waiting for. Can contain simple strings for direct fields or objects for relationship dependencies.
    /// </summary>
    [JsonPropertyName("waiting_on")]
    public IEnumerable<
        OneOf<string, ContextInstancePendingEvaluationWaitingOnItemField>
    >? WaitingOn { get; set; }

    /// <summary>
    /// When this pending evaluation was registered.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When this pending evaluation will expire.
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
