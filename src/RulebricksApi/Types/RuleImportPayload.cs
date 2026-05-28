using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Rule object accepted by /admin/rules/import. If `id` is provided, the matching rule is partially updated (all other fields optional). If `id` is omitted, a new rule is created with all other fields required. This object intentionally preserves raw rule document casing (for example, `requestSchema`, `sampleRequest`, and `createdAt`) to support `.rbm` round-tripping.
/// </summary>
[Serializable]
public record RuleImportPayload : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Optional. If omitted, a new rule is created with an auto-generated UUID. If provided, the endpoint performs a partial update on the matching rule.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Optional stable ID for cross-workspace import/export identity.
    /// </summary>
    [JsonPropertyName("stable_id")]
    public string? StableId { get; set; }

    /// <summary>
    /// Optional. Auto-generated if omitted during creation. Accepted if provided.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    /// <summary>
    /// Rule name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Rule description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Creation timestamp.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Last update timestamp.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Current publish state. Set with `_publish`/`_unpublish` to control publish transitions on import.
    /// </summary>
    [JsonPropertyName("published")]
    public bool? Published { get; set; }

    /// <summary>
    /// Optional user-defined metadata for external IDs or implementation mappings.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// If true, backend publishes this rule and snapshots published_* fields from draft fields.
    /// </summary>
    [JsonPropertyName("_publish")]
    public bool? Publish { get; set; }

    /// <summary>
    /// If true, backend unpublishes this rule.
    /// </summary>
    [JsonPropertyName("_unpublish")]
    public bool? Unpublish { get; set; }

    /// <summary>
    /// Draft request schema.
    /// </summary>
    [JsonPropertyName("requestSchema")]
    public IEnumerable<RuleImportSchemaField>? RequestSchema { get; set; }

    /// <summary>
    /// Draft response schema.
    /// </summary>
    [JsonPropertyName("responseSchema")]
    public IEnumerable<RuleImportSchemaField>? ResponseSchema { get; set; }

    /// <summary>
    /// Sample request JSON.
    /// </summary>
    [JsonPropertyName("sampleRequest")]
    public Dictionary<string, object?>? SampleRequest { get; set; }

    /// <summary>
    /// Request payload used by editor test tab.
    /// </summary>
    [JsonPropertyName("testRequest")]
    public Dictionary<string, object?>? TestRequest { get; set; }

    /// <summary>
    /// Sample response JSON.
    /// </summary>
    [JsonPropertyName("sampleResponse")]
    public Dictionary<string, object?>? SampleResponse { get; set; }

    /// <summary>
    /// Draft condition rows.
    /// </summary>
    [JsonPropertyName("conditions")]
    public IEnumerable<RuleImportConditionRow>? Conditions { get; set; }

    /// <summary>
    /// Optional row grouping definitions.
    /// </summary>
    [JsonPropertyName("groups")]
    public Dictionary<string, Dictionary<string, object?>>? Groups { get; set; }

    /// <summary>
    /// Optional rule-level settings.
    /// </summary>
    [JsonPropertyName("settings")]
    public Dictionary<string, object?>? Settings { get; set; }

    /// <summary>
    /// Optional rule test suite.
    /// </summary>
    [JsonPropertyName("testSuite")]
    public IEnumerable<Dictionary<string, object?>>? TestSuite { get; set; }

    /// <summary>
    /// Rule history entries.
    /// </summary>
    [JsonPropertyName("history")]
    public IEnumerable<Dictionary<string, object?>>? History { get; set; }

    /// <summary>
    /// Publish timestamp.
    /// </summary>
    [JsonPropertyName("publishedAt")]
    public DateTime? PublishedAt { get; set; }

    /// <summary>
    /// Optional published request schema override.
    /// </summary>
    [JsonPropertyName("published_requestSchema")]
    public IEnumerable<RuleImportSchemaField>? PublishedRequestSchema { get; set; }

    /// <summary>
    /// Optional published response schema override.
    /// </summary>
    [JsonPropertyName("published_responseSchema")]
    public IEnumerable<RuleImportSchemaField>? PublishedResponseSchema { get; set; }

    /// <summary>
    /// Optional published conditions override.
    /// </summary>
    [JsonPropertyName("published_conditions")]
    public IEnumerable<RuleImportConditionRow>? PublishedConditions { get; set; }

    /// <summary>
    /// Optional published groups override.
    /// </summary>
    [JsonPropertyName("published_groups")]
    public Dictionary<string, Dictionary<string, object?>?>? PublishedGroups { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
