using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record SolveContextFlowRequest
{
    /// <summary>
    /// The unique slug for the context.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    /// <summary>
    /// The unique identifier for the context instance.
    /// </summary>
    [JsonIgnore]
    public required string Instance { get; set; }

    /// <summary>
    /// The unique slug for the flow.
    /// </summary>
    [JsonIgnore]
    public required string FlowSlug { get; set; }

    /// <summary>
    /// Additional data to merge with instance state for flow execution.
    /// </summary>
    [JsonPropertyName("additionalData")]
    public Dictionary<string, object?>? AdditionalData { get; set; }

    /// <summary>
    /// Whether to persist derived outputs to the instance.
    /// </summary>
    [JsonPropertyName("persist")]
    public bool? Persist { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
