using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ObjectUpsertConflictResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Conflict message.
    /// </summary>
    [JsonPropertyName("error")]
    public required string Error { get; set; }

    /// <summary>
    /// Values the object would generate but cannot adopt or overwrite. Present for value-name collisions and omitted for conflicts without colliding values.
    /// </summary>
    [JsonPropertyName("collisions")]
    public IEnumerable<ObjectValueCollision>? Collisions { get; set; }

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
