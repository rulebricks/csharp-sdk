using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Error response when flow execution fails
/// </summary>
[Serializable]
public record FlowExecutionError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Error message describing what went wrong during flow execution
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// Identifier of the node where the error occurred (if applicable)
    /// </summary>
    [JsonPropertyName("node")]
    public string? Node { get; set; }

    /// <summary>
    /// Additional error details
    /// </summary>
    [JsonPropertyName("details")]
    public Dictionary<string, object?>? Details { get; set; }

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
