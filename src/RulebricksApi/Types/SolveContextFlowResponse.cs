using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Response after executing a flow against a context instance.
/// </summary>
[Serializable]
public record SolveContextFlowResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether the flow executed successfully.
    /// </summary>
    [JsonPropertyName("status")]
    public SolveContextFlowResponseStatus? Status { get; set; }

    /// <summary>
    /// Combined identifier in format 'contextSlug:instanceId'.
    /// </summary>
    [JsonPropertyName("context")]
    public string? Context { get; set; }

    /// <summary>
    /// The slug of the flow that was executed.
    /// </summary>
    [JsonPropertyName("flow")]
    public string? Flow { get; set; }

    /// <summary>
    /// The flow execution output.
    /// </summary>
    [JsonPropertyName("result")]
    public Dictionary<string, object?>? Result { get; set; }

    /// <summary>
    /// Resource usage information for the flow execution.
    /// </summary>
    [JsonPropertyName("usage")]
    public Dictionary<string, object?>? Usage { get; set; }

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
