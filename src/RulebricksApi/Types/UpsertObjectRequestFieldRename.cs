using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Renames a field while preserving generated value IDs.
/// </summary>
[Serializable]
public record UpsertObjectRequestFieldRename : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Existing field key or schema path.
    /// </summary>
    [JsonPropertyName("from_key")]
    public required string FromKey { get; set; }

    /// <summary>
    /// New field key or schema path.
    /// </summary>
    [JsonPropertyName("to_key")]
    public required string ToKey { get; set; }

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
