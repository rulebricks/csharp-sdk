using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Contexts;

[Serializable]
public record CreateRelationshipRequest
{
    /// <summary>
    /// The unique identifier for the context.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The ID of the target context.
    /// </summary>
    [JsonPropertyName("to_context_id")]
    public required string ToContextId { get; set; }

    /// <summary>
    /// The type of relationship.
    /// </summary>
    [JsonPropertyName("relation_type")]
    public required CreateRelationshipRequestRelationType RelationType { get; set; }

    /// <summary>
    /// The field key to use as the foreign key.
    /// </summary>
    [JsonPropertyName("foreign_key_fact")]
    public required string ForeignKeyFact { get; set; }

    /// <summary>
    /// Display name for the relationship.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Description of the relationship.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
