using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Response after solving a rule against a context instance.
/// </summary>
[Serializable]
public record SolveContextRuleResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether the rule executed successfully.
    /// </summary>
    [JsonPropertyName("status")]
    public SolveContextRuleResponseStatus? Status { get; set; }

    /// <summary>
    /// Combined identifier in format 'contextSlug:instanceId'.
    /// </summary>
    [JsonPropertyName("context")]
    public string? Context { get; set; }

    /// <summary>
    /// The slug of the rule that was executed.
    /// </summary>
    [JsonPropertyName("rule")]
    public string? Rule { get; set; }

    /// <summary>
    /// The rule evaluation result (output values).
    /// </summary>
    [JsonPropertyName("result")]
    public Dictionary<string, object?>? Result { get; set; }

    /// <summary>
    /// List of field keys that were written back to the context instance.
    /// </summary>
    [JsonPropertyName("written_to_context")]
    public IEnumerable<string>? WrittenToContext { get; set; }

    /// <summary>
    /// Results from any cascaded evaluations triggered by the rule outputs.
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
