using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record DeleteObjectsRequest
{
    /// <summary>
    /// Object ID or exact name
    /// </summary>
    [JsonIgnore]
    public required string ObjectId { get; set; }

    /// <summary>
    /// What happens to the values this object generated: 'archive' (default) or 'detach'.
    /// </summary>
    [JsonIgnore]
    public DeleteObjectsRequestValues? Values { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
