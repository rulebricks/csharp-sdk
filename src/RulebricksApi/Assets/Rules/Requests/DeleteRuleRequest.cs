using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[Serializable]
public record DeleteRuleRequest
{
    /// <summary>
    /// The ID of the rule to delete.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
