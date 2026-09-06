using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Response after updating a context.
/// </summary>
[Serializable]
public record UpdateContextResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier of the updated context.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The slug of the updated context.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// The name of the updated context.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("schema")]
    public ContextSchema? Schema { get; set; }

    [JsonPropertyName("identity_fact")]
    public string? IdentityFact { get; set; }

    [JsonPropertyName("ttl_seconds")]
    public int? TtlSeconds { get; set; }

    [JsonPropertyName("history_limit")]
    public int? HistoryLimit { get; set; }

    [JsonPropertyName("on_schema_mismatch")]
    public UpdateContextResponseOnSchemaMismatch? OnSchemaMismatch { get; set; }

    [JsonPropertyName("auto_execute_decisions")]
    public bool? AutoExecuteDecisions { get; set; }

    [JsonPropertyName("source_objects")]
    public IEnumerable<string>? SourceObjects { get; set; }

    [JsonPropertyName("user_groups")]
    public IEnumerable<string>? UserGroups { get; set; }

    [JsonPropertyName("folder")]
    public string? Folder { get; set; }

    /// <summary>
    /// Timestamp of when the context was updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

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
