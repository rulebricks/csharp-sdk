using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A pending dependency. Fact dependencies identify the context instance and missing fields; relationship dependencies also include the relationship name and derived facts that depend on it.
/// </summary>
[Serializable]
public record ContextWaitingOn : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Context slug that must supply the dependency. May be null when relationship metadata cannot resolve a target.
    /// </summary>
    [JsonPropertyName("context")]
    public string? Context { get; set; }

    /// <summary>
    /// Context instance identity for direct fact dependencies.
    /// </summary>
    [JsonPropertyName("instance")]
    public string? Instance { get; set; }

    /// <summary>
    /// Missing fact paths, or [`*`] for a relationship dependency.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<string>? Fields { get; set; }

    /// <summary>
    /// Relationship name for relationship dependencies.
    /// </summary>
    [JsonPropertyName("relation")]
    public string? Relation { get; set; }

    /// <summary>
    /// Derived fact keys waiting on this relationship.
    /// </summary>
    [JsonPropertyName("dependentDerivedFields")]
    public IEnumerable<string>? DependentDerivedFields { get; set; }

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
