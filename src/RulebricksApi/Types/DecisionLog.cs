using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record DecisionLog
{
    [JsonPropertyName("request")]
    public DecisionLogRequest? Request { get; set; }

    [JsonPropertyName("response")]
    public DecisionLogResponse? Response { get; set; }

    [JsonPropertyName("decision")]
    public DecisionLogDecision? Decision { get; set; }

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
