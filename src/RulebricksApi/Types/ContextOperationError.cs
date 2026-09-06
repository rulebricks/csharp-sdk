using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A Context operation failed. Earlier chunks can already be committed. Omitted committed IDs do not prove that no write occurred when the outcome is uncertain.
/// </summary>
[Serializable]
public record ContextOperationError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("error")]
    public required string Error { get; set; }

    /// <summary>
    /// Number of distinct instances confirmed committed before failure, when known.
    /// </summary>
    [JsonPropertyName("committed_count")]
    public int? CommittedCount { get; set; }

    /// <summary>
    /// Identities confirmed committed before failure, when known.
    /// </summary>
    [JsonPropertyName("committed_instance_ids")]
    public IEnumerable<string>? CommittedInstanceIds { get; set; }

    /// <summary>
    /// Identities with a known failed write, when available.
    /// </summary>
    [JsonPropertyName("failed_instance_ids")]
    public IEnumerable<string>? FailedInstanceIds { get; set; }

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
