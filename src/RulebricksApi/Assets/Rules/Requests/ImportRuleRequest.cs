using global::System.Text.Json.Serialization;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[Serializable]
public record ImportRuleRequest
{
    [JsonPropertyName("rule")]
    public required RuleImportPayload Rule { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
