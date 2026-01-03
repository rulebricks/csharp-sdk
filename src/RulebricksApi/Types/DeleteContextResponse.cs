using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Response after deleting a context.
/// </summary>
[Serializable]
public record DeleteContextResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Success message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Slugs of rules that were unbound from the deleted context.
    /// </summary>
    [JsonPropertyName("unbound_rules")]
    public IEnumerable<string>? UnboundRules { get; set; }

    /// <summary>
    /// Slugs of flows that were unbound from the deleted context.
    /// </summary>
    [JsonPropertyName("unbound_flows")]
    public IEnumerable<string>? UnboundFlows { get; set; }

    /// <summary>
    /// Number of pending evaluations that were cancelled when the context was deleted.
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
