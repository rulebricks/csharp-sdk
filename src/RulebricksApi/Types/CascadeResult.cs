using System.Text.Json;
using System.Text.Json.Serialization;
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
    /// Whether the evaluation succeeded.
    /// </summary>
    [JsonPropertyName("status")]
    public CascadeResultStatus? Status { get; set; }

    /// <summary>
    /// The evaluation output.
    /// </summary>
    [JsonPropertyName("result")]
    public Dictionary<string, object?>? Result { get; set; }

    /// <summary>
    /// Whether this was auto-executed (true) or from a registered pending evaluation (false).
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
