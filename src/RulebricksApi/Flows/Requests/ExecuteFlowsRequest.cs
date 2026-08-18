using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ExecuteFlowsRequest
{
    /// <summary>
    /// The unique identifier for the resource.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    /// <summary>
    /// The version of the resource to target: a published version number (e.g. `3`), a release environment slug (e.g. `production`, always lowercase), or `latest` (default) to use the current published version.
    /// </summary>
    [JsonIgnore]
    public string Version { get; set; } = "latest";

    [JsonIgnore]
    public Dictionary<string, object?> Body { get; set; } = new Dictionary<string, object?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
