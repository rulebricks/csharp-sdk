using global::System.Text.Json.Serialization;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Contexts;

[Serializable]
public record CreateContextRequest
{
    /// <summary>
    /// The name of the context. The context's slug is generated from it (suffixed on collision).
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The description of the context.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The context's schema: an object with `base` (stored facts; at least one required) and optional `derived` (expression-computed facts) field arrays.
    /// </summary>
    [JsonPropertyName("schema")]
    public required ContextSchema Schema { get; set; }

    /// <summary>
    /// The fact key to use as the unique identifier for instances. Must be a key from schema.base.
    /// </summary>
    [JsonPropertyName("identity_fact")]
    public required string IdentityFact { get; set; }

    /// <summary>
    /// When true (default), bound rules and flows automatically execute when their inputs are satisfied.
    /// </summary>
    [JsonPropertyName("auto_execute_decisions")]
    public bool? AutoExecuteDecisions { get; set; }

    /// <summary>
    /// Time-to-live in seconds for live context instances (60 seconds to 30 days). Instances expire after this duration; each write extends the expiry.
    /// </summary>
    [JsonPropertyName("ttl_seconds")]
    public int? TtlSeconds { get; set; }

    /// <summary>
    /// Maximum number of history entries to retain per field.
    /// </summary>
    [JsonPropertyName("history_limit")]
    public int? HistoryLimit { get; set; }

    /// <summary>
    /// How to handle submitted fields that don't match the schema: `ignore` drops them, `reject` fails the request (or the batch item), `store` persists them alongside declared facts.
    /// </summary>
    [JsonPropertyName("on_schema_mismatch")]
    public CreateContextRequestOnSchemaMismatch? OnSchemaMismatch { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
