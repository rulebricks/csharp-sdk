using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record DynamicValue
{
    /// <summary>
    /// Unique identifier for the dynamic value.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Name of the dynamic value (may include dot notation for nested properties).
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Type identifier for the value (e.g., 'string', 'number', 'boolean', 'list', 'function', etc.)
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("value")]
    public object? Value { get; set; }

    /// <summary>
    /// Rules that use this dynamic value (only included when 'include=usage' parameter is used).
    /// </summary>
    [JsonPropertyName("usages")]
    public IEnumerable<RuleUsage>? Usages { get; set; }

    /// <summary>
    /// Access groups assigned to this value.
    /// </summary>
    [JsonPropertyName("accessGroups")]
    public IEnumerable<string>? AccessGroups { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
