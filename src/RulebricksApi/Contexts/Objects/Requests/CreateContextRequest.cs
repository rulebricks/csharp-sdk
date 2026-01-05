using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Contexts;

[Serializable]
public record CreateContextRequest
{
    /// <summary>
    /// The name of the context.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Optional custom slug. Auto-generated if not provided.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// The description of the context.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Initial schema fields for the context. At least one field must be defined.
    /// </summary>
    [JsonPropertyName("schema")]
    public IEnumerable<CreateContextRequestSchemaItem> Schema { get; set; } =
        new List<CreateContextRequestSchemaItem>();

    /// <summary>
    /// The field key to use as the unique identifier for instances. Must be a key from the schema.
    /// </summary>
    [JsonPropertyName("identity_fact")]
    public required string IdentityFact { get; set; }

    /// <summary>
    /// When true (default), bound rules and flows automatically execute when their inputs are satisfied.
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
    /// How to handle fields that don't match the schema.
    /// </summary>
    [JsonPropertyName("on_schema_mismatch")]
    public CreateContextRequestOnSchemaMismatch? OnSchemaMismatch { get; set; }

    /// <summary>
    /// Webhook URL called when a rule or flow successfully solves.
    /// </summary>
    [JsonPropertyName("webhook_on_solve")]
    public string? WebhookOnSolve { get; set; }

    /// <summary>
    /// Webhook URL called when a live context expires due to TTL.
    /// </summary>
    [JsonPropertyName("webhook_on_expire")]
    public string? WebhookOnExpire { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
