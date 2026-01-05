using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ExecuteContextsRequest
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

    [JsonIgnore]
    public Dictionary<string, object?> Body { get; set; } = new Dictionary<string, object?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
