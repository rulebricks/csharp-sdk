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
    /// What happens to generated values: 'archive' (default) permanently deletes unused values and archives referenced values; 'detach' retains all values as active ordinary values.
    /// </summary>
    [JsonIgnore]
    public DeleteObjectsRequestValues? Values { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
