using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Tests;

[Serializable]
public record ListRulesRequest
{
    /// <summary>
    /// The unique identifier for the resource.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
