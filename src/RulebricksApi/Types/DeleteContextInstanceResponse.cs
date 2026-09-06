using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Response after deleting a context instance.
/// </summary>
[Serializable]
public record DeleteContextInstanceResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The source was deleted but dependent reevaluation did not complete.
    /// </summary>
    [JsonPropertyName("execution_degraded")]
    public string? ExecutionDegraded { get; set; }

    [JsonPropertyName("cascaded")]
    public IEnumerable<ContextCascadeSummary>? Cascaded { get; set; }

    /// <summary>
    /// Information needed to reconcile dependent work after physical source deletion. Retain this response; an identical delete cannot reconstruct removed facts.
    /// </summary>
    [JsonPropertyName("cascade_recovery")]
    public DeleteContextInstanceResponseCascadeRecovery? CascadeRecovery { get; set; }

    /// <summary>
    /// Success message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Number of pending evaluations that were cancelled when the instance was deleted.
    /// </summary>
    [JsonPropertyName("pending_evaluations_cancelled")]
    public int? PendingEvaluationsCancelled { get; set; }

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
