using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record DecisionLogDecision
{
    [JsonPropertyName("conditions")]
    public IEnumerable<
        Dictionary<string, DecisionLogDecisionConditionsItemValue>
    >? Conditions { get; set; }

    [JsonPropertyName("successIdxs")]
    public IEnumerable<int>? SuccessIdxs { get; set; }

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
