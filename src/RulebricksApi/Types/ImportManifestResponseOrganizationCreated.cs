using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// IDs of any organizational folders created during import.
/// </summary>
[Serializable]
public record ImportManifestResponseOrganizationCreated : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("entity_set_id")]
    public string? EntitySetId { get; set; }

    [JsonPropertyName("rule_tag_id")]
    public string? RuleTagId { get; set; }

    [JsonPropertyName("flow_tag_id")]
    public string? FlowTagId { get; set; }

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
