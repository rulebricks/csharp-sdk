using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

public record ListValue
{
    /// <summary>
    /// The list value
    /// </summary>
    [JsonPropertyName("value")]
    public IEnumerable<
        OneOf<string, double, bool, object, IEnumerable<object>>
    >? Value { get; set; }

    /// <summary>
    /// Unique identifier for the dynamic value.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Name of the dynamic value.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Rules that use this dynamic value.
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
