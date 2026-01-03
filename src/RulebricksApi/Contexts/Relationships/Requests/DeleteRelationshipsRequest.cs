using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Contexts;

[Serializable]
public record DeleteRelationshipsRequest
{
    /// <summary>
    /// The unique identifier for the context.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The unique identifier for the relationship.
    /// </summary>
    [JsonIgnore]
    public required string Relationship { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
