using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ContextRelationshipsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The context these relationships belong to.
    /// </summary>
    [JsonPropertyName("context")]
    public ContextRelationshipsResponseContext? Context { get; set; }

    [JsonPropertyName("outgoing")]
    public IEnumerable<ContextRelationshipOutgoing>? Outgoing { get; set; }

    [JsonPropertyName("incoming")]
    public IEnumerable<ContextRelationshipIncoming>? Incoming { get; set; }

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
