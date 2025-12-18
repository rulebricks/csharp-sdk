using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record SolveRulesRequest
{
    /// <summary>
    /// The unique identifier for the resource.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    [JsonIgnore]
    public Dictionary<string, object?> Body { get; set; } = new Dictionary<string, object?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
