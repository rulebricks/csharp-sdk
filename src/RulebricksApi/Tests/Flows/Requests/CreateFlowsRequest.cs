using System.Text.Json.Serialization;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Tests;

[Serializable]
public record CreateFlowsRequest
{
    /// <summary>
    /// The unique identifier for the resource.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    [JsonIgnore]
    public required CreateTestRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
