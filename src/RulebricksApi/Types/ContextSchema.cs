using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// The schema definition for a context.
/// </summary>
[Serializable]
public record ContextSchema : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// User-defined base fields for the context.
    /// </summary>
    [JsonPropertyName("base")]
    public IEnumerable<ContextSchemaField>? Base { get; set; }

    /// <summary>
    /// Fields derived from bound rule/flow outputs.
    /// </summary>
    [JsonPropertyName("derived")]
    public IEnumerable<ContextSchemaField>? Derived { get; set; }

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
