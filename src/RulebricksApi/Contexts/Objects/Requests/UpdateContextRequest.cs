using global::System.Text.Json.Serialization;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Contexts;

[Serializable]
public record UpdateContextRequest
{
    /// <summary>
    /// The unique identifier for the context.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the context. Changing it regenerates the context's slug.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The description of the context.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Updated schema for the context: an object with `base` and optional `derived` field arrays.
    /// </summary>
    [JsonPropertyName("schema")]
    public ContextSchema? Schema { get; set; }

    /// <summary>
    /// The fact key to use as the unique identifier for instances. Must be a key from schema.base. Caution: changing this on a context with live instances changes how future writes resolve instances.
    /// </summary>
    [JsonPropertyName("identity_fact")]
    public string? IdentityFact { get; set; }

    /// <summary>
    /// When true, bound rules and flows automatically execute when their inputs are satisfied.
    /// </summary>
    [JsonPropertyName("auto_execute_decisions")]
    public bool? AutoExecuteDecisions { get; set; }

    /// <summary>
    /// Time-to-live in seconds for live context instances (60 seconds to 30 days). Instances expire after this duration.
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
    public UpdateContextRequestOnSchemaMismatch? OnSchemaMismatch { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
