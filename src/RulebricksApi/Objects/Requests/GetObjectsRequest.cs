using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record GetObjectsRequest
{
    /// <summary>
    /// Object ID or exact name
    /// </summary>
    [JsonIgnore]
    public required string ObjectId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
