using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record DeleteContextsRequest
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
