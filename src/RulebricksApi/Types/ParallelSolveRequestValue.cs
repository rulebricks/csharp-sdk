using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record ParallelSolveRequestValue
{
    /// <summary>
    /// Slug of the rule to execute
    /// </summary>
    [JsonPropertyName("$rule")]
    public string? Rule { get; set; }

    /// <summary>
    /// Slug of the flow to execute
    /// </summary>
    [JsonPropertyName("$flow")]
    public string? Flow { get; set; }

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
