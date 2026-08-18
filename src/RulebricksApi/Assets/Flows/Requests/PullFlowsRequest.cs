using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[Serializable]
public record PullFlowsRequest
{
    /// <summary>
    /// The ID of the flow to export (provide `id` or `slug`).
    /// </summary>
    [JsonIgnore]
    public string? Id { get; set; }

    /// <summary>
    /// The slug of the flow to export (provide `id` or `slug`).
    /// </summary>
    [JsonIgnore]
    public string? Slug { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
