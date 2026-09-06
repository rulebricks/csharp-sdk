using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Summary of one dependent context re-evaluated through a relationship.
/// </summary>
[Serializable]
public record ContextCascadeSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Relationship type used to find dependent work.
    /// </summary>
    [JsonPropertyName("relation_type")]
    public string? RelationType { get; set; }

    /// <summary>
    /// Foreign key used to find dependent identities.
    /// </summary>
    [JsonPropertyName("foreign_key_field")]
    public string? ForeignKeyField { get; set; }

    /// <summary>
    /// Known failed dependent identities from a bounded page.
    /// </summary>
    [JsonPropertyName("failed_instance_ids")]
    public IEnumerable<string>? FailedInstanceIds { get; set; }

    [JsonPropertyName("rejected")]
    public int? Rejected { get; set; }

    /// <summary>
    /// The dependent context slug.
    /// </summary>
    [JsonPropertyName("context")]
    public required string Context { get; set; }

    /// <summary>
    /// The relationship that linked the contexts.
    /// </summary>
    [JsonPropertyName("relation")]
    public required string Relation { get; set; }

    /// <summary>
    /// Distinct existing dependent instances re-evaluated.
    /// </summary>
    [JsonPropertyName("instances")]
    public int? Instances { get; set; }

    [JsonPropertyName("executed")]
    public int? Executed { get; set; }

    [JsonPropertyName("evaluation_errors")]
    public int? EvaluationErrors { get; set; }

    [JsonPropertyName("infrastructure_errors")]
    public int? InfrastructureErrors { get; set; }

    [JsonPropertyName("skipped")]
    public int? Skipped { get; set; }

    /// <summary>
    /// Present when dependent data was committed but execution was unavailable.
    /// </summary>
    [JsonPropertyName("execution_degraded")]
    public string? ExecutionDegraded { get; set; }

    /// <summary>
    /// Present when the dependent relationship lookup or cascade failed.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

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
