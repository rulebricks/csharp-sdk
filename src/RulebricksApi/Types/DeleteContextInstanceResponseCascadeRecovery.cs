using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Information needed to reconcile dependent work after physical source deletion. Retain this response; an identical delete cannot reconstruct removed facts.
/// </summary>
[Serializable]
public record DeleteContextInstanceResponseCascadeRecovery : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("context")]
    public string? Context { get; set; }

    [JsonPropertyName("previous_state")]
    public Dictionary<string, object?>? PreviousState { get; set; }

    [JsonPropertyName("action")]
    public string? Action { get; set; }

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
