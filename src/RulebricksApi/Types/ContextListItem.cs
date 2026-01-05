using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Summary of a context for listing. Uses counts instead of full arrays.
/// </summary>
[Serializable]
public record ContextListItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The field key used as the unique identifier for instances.
    /// </summary>
    [JsonPropertyName("identity_fact")]
    public string? IdentityFact { get; set; }

    [JsonPropertyName("schema")]
    public ContextSchema? Schema { get; set; }

    [JsonPropertyName("folder")]
    public ContextListItemFolder? Folder { get; set; }

    /// <summary>
    /// Number of rules bound to this context.
    /// </summary>
    [JsonPropertyName("bound_rules_count")]
    public int? BoundRulesCount { get; set; }

    /// <summary>
    /// Number of flows bound to this context.
    /// </summary>
    [JsonPropertyName("bound_flows_count")]
    public int? BoundFlowsCount { get; set; }

    /// <summary>
    /// Total number of relationships for this context.
    /// </summary>
    [JsonPropertyName("relationships_count")]
    public int? RelationshipsCount { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// The unique identifier for the context.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the context.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The unique slug for the context used in API requests.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// The description of the context.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// When true, bound rules and flows automatically execute when their inputs are satisfied. When false, users must manually call /solve or /flows endpoints.
    /// </summary>
    [JsonPropertyName("auto_execute_decisions")]
    public bool? AutoExecuteDecisions { get; set; }

    /// <summary>
    /// Time-to-live in seconds for live context instances. Instances expire after this duration.
    /// </summary>
    [JsonPropertyName("ttl_seconds")]
    public int? TtlSeconds { get; set; }

    /// <summary>
    /// Maximum number of history entries to retain per field.
    /// </summary>
    [JsonPropertyName("history_limit")]
    public int? HistoryLimit { get; set; }

    /// <summary>
    /// How to handle fields that don't match the schema: 'ignore' filters them out, 'reject' returns an error.
    /// </summary>
    [JsonPropertyName("on_schema_mismatch")]
    public ContextBaseOnSchemaMismatch? OnSchemaMismatch { get; set; }

    /// <summary>
    /// Webhook URL called when a rule or flow successfully solves for a live context.
    /// </summary>
    [JsonPropertyName("webhook_on_solve")]
    public string? WebhookOnSolve { get; set; }

    /// <summary>
    /// Webhook URL called when a live context expires due to TTL.
    /// </summary>
    [JsonPropertyName("webhook_on_expire")]
    public string? WebhookOnExpire { get; set; }

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
