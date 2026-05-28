using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record RuleDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The date this rule was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The date this rule was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Whether the rule is currently published.
    /// </summary>
    [JsonPropertyName("published")]
    public bool? Published { get; set; }

    /// <summary>
    /// The number of condition rows configured for the rule. Uses the published condition count when the rule is published, otherwise the draft condition count.
    /// </summary>
    [JsonPropertyName("no_conditions")]
    public int? NoConditions { get; set; }

    /// <summary>
    /// Optional user-defined metadata for API-first integrations.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// User groups that can access this rule.
    /// </summary>
    [JsonPropertyName("user_groups")]
    public IEnumerable<string>? UserGroups { get; set; }

    [JsonPropertyName("folder")]
    public Folder? Folder { get; set; }

    /// <summary>
    /// The context this rule is bound to (if any). Rules bound to a context have their inputs/outputs mapped to context fields.
    /// </summary>
    [JsonPropertyName("context")]
    public RuleDetailContext? Context { get; set; }

    /// <summary>
    /// The request schema for the rule. Uses published schema when published, otherwise draft schema.
    /// </summary>
    [JsonPropertyName("request_schema")]
    public IEnumerable<SchemaField>? RequestSchema { get; set; }

    /// <summary>
    /// The response schema for the rule. Uses published schema when published, otherwise draft schema.
    /// </summary>
    [JsonPropertyName("response_schema")]
    public IEnumerable<SchemaField>? ResponseSchema { get; set; }

    /// <summary>
    /// The unique identifier for the rule.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the rule.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The description of the rule.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The unique slug for the rule used in API requests.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

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
