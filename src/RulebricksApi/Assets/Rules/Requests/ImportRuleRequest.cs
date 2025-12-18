using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[Serializable]
public record ImportRuleRequest
{
    /// <summary>
    /// The rule data to import.
    /// </summary>
    [JsonPropertyName("rule")]
    public Dictionary<string, object?> Rule { get; set; } = new Dictionary<string, object?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
