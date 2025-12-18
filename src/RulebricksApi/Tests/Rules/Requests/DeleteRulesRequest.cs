using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Tests;

[Serializable]
public record DeleteRulesRequest
{
    /// <summary>
    /// The unique identifier for the resource.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    /// <summary>
    /// The ID of the test.
    /// </summary>
    [JsonIgnore]
    public required string TestId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
