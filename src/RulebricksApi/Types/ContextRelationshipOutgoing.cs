using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ContextRelationshipOutgoing : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("targetContext")]
    public ContextRelationshipOutgoingTargetContext? TargetContext { get; set; }

    /// <summary>
    /// The unique identifier for the relationship.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The type of relationship.
    /// </summary>
    [JsonPropertyName("type")]
    public ContextRelationshipBaseType? Type { get; set; }

    /// <summary>
    /// The field key used as the foreign key.
    /// </summary>
    [JsonPropertyName("foreignKey")]
    public string? ForeignKey { get; set; }

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
