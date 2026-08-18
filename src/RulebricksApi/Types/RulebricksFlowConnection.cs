using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A directed connection between two node refs. Data connections carry a property from `output` to `input`; control connections (`control: true`) gate the target on a Continue If.
/// </summary>
[Serializable]
public record RulebricksFlowConnection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Source node ref.
    /// </summary>
    [JsonPropertyName("from")]
    public required string From { get; set; }

    /// <summary>
    /// Target node ref.
    /// </summary>
    [JsonPropertyName("to")]
    public required string To { get; set; }

    /// <summary>
    /// (data) Source output key: a declared output of the source node, or - for a rule/origin source - one of the referenced rule's response field keys (an origin also exposes `request_&lt;field&gt;` passthroughs). Free-form; validated against the resolved rule at import time.
    /// </summary>
    [JsonPropertyName("output")]
    public string? Output { get; set; }

    /// <summary>
    /// (data) Target input key. Required for rule/entity targets, where it must be one of the referenced rule's request field keys. Free-form; validated against the resolved rule at import time.
    /// </summary>
    [JsonPropertyName("input")]
    public string? Input { get; set; }

    /// <summary>
    /// Set true for a Continue If gating edge (carries no data).
    /// </summary>
    [JsonPropertyName("control")]
    public bool? Control { get; set; }

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
