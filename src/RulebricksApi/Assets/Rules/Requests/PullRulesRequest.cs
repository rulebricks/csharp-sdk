using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[Serializable]
public record PullRulesRequest
{
    /// <summary>
    /// The ID of the rule to export.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
