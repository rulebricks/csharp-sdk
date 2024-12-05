using System.Text.Json.Serialization;
using OneOf;
using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

public record ListDynamicValuesResponseItem
{
    /// <summary>
    /// Unique identifier for the dynamic value.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Name of the dynamic value.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// Data type of the dynamic value.
    /// </summary>
    [JsonPropertyName("type")]
    public ListDynamicValuesResponseItemType? Type { get; init; }

    /// <summary>
    /// Value of the dynamic value.
    /// </summary>
    [JsonPropertyName("value")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<string, double, bool, IEnumerable<object>>>))]
    public OneOf<string, double, bool, IEnumerable<object>>? Value { get; init; }

    [JsonPropertyName("usages")]
    public IEnumerable<ListDynamicValuesResponseItemUsagesItem>? Usages { get; init; }
}
