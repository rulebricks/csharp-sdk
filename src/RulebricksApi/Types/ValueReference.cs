using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A value-to-value reference marker. On writes, reference a value by name with { "$ref": "<value name="">" } or by ID with { "$rb": "globalValue", "id": "<value id="">" }. Name references are resolved and stored as ID references, so renames never break them. A scalar payload may be a single reference; list payloads may mix literal items and references. Reads with resolve=false return the stored id-based markers.</value></value>
/// </summary>
[Serializable]
public record ValueReference : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Full name of the referenced value (write-time form), e.g. 'Medical Codes.A123'.
    /// </summary>
    [JsonPropertyName("$ref")]
    public string? Ref { get; set; }

    /// <summary>
    /// Marker discriminator for id-based references.
    /// </summary>
    [JsonPropertyName("$rb")]
    public ValueReferenceRb? Rb { get; set; }

    /// <summary>
    /// Id of the referenced value (stored form).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Denormalized display name of the referenced value (stored form; may lag renames).
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

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
