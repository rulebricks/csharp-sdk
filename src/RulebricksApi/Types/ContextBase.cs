using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Base properties for a context.
/// </summary>
[Serializable]
public record ContextBase : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
