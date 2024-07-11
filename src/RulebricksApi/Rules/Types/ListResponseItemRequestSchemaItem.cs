using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ListResponseItemRequestSchemaItem
{
    /// <summary>
    /// The key for the request field.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; init; }

    /// <summary>
    /// Whether the field is visible in the rule editor.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; init; }

    /// <summary>
    /// The name of the request field.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The description of the request field.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// The data type of the request field.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// The default value of the request field.
    /// </summary>
    [JsonPropertyName("defaultValue")]
    public string? DefaultValue { get; init; }

    /// <summary>
    /// The computed default value of the request field.
    /// </summary>
    [JsonPropertyName("defaultComputedValue")]
    public string? DefaultComputedValue { get; init; }

    /// <summary>
    /// The transformation applied to the request field.
    /// </summary>
    [JsonPropertyName("transform")]
    public string? Transform { get; init; }
}
