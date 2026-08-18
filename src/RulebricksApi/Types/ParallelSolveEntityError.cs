using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Reported in a parallel-solve response slot when an individual rule or flow could not be executed. The reserved `$error` key cannot collide with a rule/flow's own output fields.
/// </summary>
[Serializable]
public record ParallelSolveEntityError : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Details of the per-entity failure.
    /// </summary>
    [JsonPropertyName("$error")]
    public required ParallelSolveEntityErrorError Error { get; set; }

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
