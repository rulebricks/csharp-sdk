using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// The state of the test after execution.
/// </summary>
[Serializable]
public record TestTestState : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Execution time in seconds
    /// </summary>
    [JsonPropertyName("duration")]
    public double? Duration { get; set; }

    /// <summary>
    /// Actual response returned
    /// </summary>
    [JsonPropertyName("response")]
    public Dictionary<string, object?>? Response { get; set; }

    [JsonPropertyName("conditions")]
    public IEnumerable<Dictionary<string, object?>>? Conditions { get; set; }

    /// <summary>
    /// HTTP status code returned
    /// </summary>
    [JsonPropertyName("http_status")]
    public int? HttpStatus { get; set; }

    [JsonPropertyName("success_idxs")]
    public IEnumerable<int>? SuccessIdxs { get; set; }

    /// <summary>
    /// Error message or flag indicating if evaluation error occurred
    /// </summary>
    [JsonPropertyName("evaluation_error")]
    public OneOf<bool, string>? EvaluationError { get; set; }

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
