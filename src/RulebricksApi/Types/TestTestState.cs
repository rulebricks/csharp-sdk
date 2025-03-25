using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// The state of the test after execution.
/// </summary>
public record TestTestState
{
    /// <summary>
    /// Execution time in seconds
    /// </summary>
    [JsonPropertyName("duration")]
    public double? Duration { get; set; }

    /// <summary>
    /// Actual response returned
    /// </summary>
    [JsonPropertyName("response")]
    public object? Response { get; set; }

    [JsonPropertyName("conditions")]
    public IEnumerable<
        Dictionary<string, TestTestStateConditionsItemValue>
    >? Conditions { get; set; }

    /// <summary>
    /// HTTP status code returned
    /// </summary>
    [JsonPropertyName("httpStatus")]
    public int? HttpStatus { get; set; }

    [JsonPropertyName("successIdxs")]
    public IEnumerable<int>? SuccessIdxs { get; set; }

    /// <summary>
    /// Error message or flag indicating if evaluation error occurred
    /// </summary>
    [JsonPropertyName("evaluationError")]
    public OneOf<bool, string>? EvaluationError { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
