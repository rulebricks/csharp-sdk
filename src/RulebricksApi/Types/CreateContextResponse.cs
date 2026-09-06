using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Summary of the newly created context.
/// </summary>
[Serializable]
public record CreateContextResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the context.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// URL-safe slug generated from the name (suffixed on collision).
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// The name of the context.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The description of the context.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("schema")]
    public ContextSchema? Schema { get; set; }

    /// <summary>
    /// The identity fact path.
    /// </summary>
    [JsonPropertyName("identity_fact")]
    public string? IdentityFact { get; set; }

    [JsonPropertyName("ttl_seconds")]
    public int? TtlSeconds { get; set; }

    [JsonPropertyName("history_limit")]
    public int? HistoryLimit { get; set; }

    [JsonPropertyName("on_schema_mismatch")]
    public CreateContextResponseOnSchemaMismatch? OnSchemaMismatch { get; set; }

    [JsonPropertyName("auto_execute_decisions")]
    public bool? AutoExecuteDecisions { get; set; }

    [JsonPropertyName("source_objects")]
    public IEnumerable<string>? SourceObjects { get; set; }

    [JsonPropertyName("user_groups")]
    public IEnumerable<string>? UserGroups { get; set; }

    [JsonPropertyName("folder")]
    public string? Folder { get; set; }

    /// <summary>
    /// Creation timestamp.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

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
