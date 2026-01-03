using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record SolveContextRuleRequest
{
    /// <summary>
    /// The unique slug for the context.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    /// <summary>
    /// The unique identifier for the context instance.
    /// </summary>
    [JsonIgnore]
    public required string Instance { get; set; }

    /// <summary>
    /// The unique slug for the rule.
    /// </summary>
    [JsonIgnore]
    public required string RuleSlug { get; set; }

    /// <summary>
    /// Additional data to merge with instance state for rule evaluation.
    /// </summary>
    [JsonPropertyName("additionalData")]
    public Dictionary<string, object?>? AdditionalData { get; set; }

    /// <summary>
    /// Whether to persist derived outputs to the instance.
    /// </summary>
    [JsonPropertyName("persist")]
    public bool? Persist { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
