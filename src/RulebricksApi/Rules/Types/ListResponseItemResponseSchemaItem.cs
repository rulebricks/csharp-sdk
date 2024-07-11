using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ListResponseItemResponseSchemaItem
{
    /// <summary>
    /// The key for the response field.
    /// </summary>
    [JsonPropertyName("key")]
    public string? Key { get; init; }

    /// <summary>
    /// Whether the field is visible in the rule editor.
    /// </summary>
    [JsonPropertyName("show")]
    public bool? Show { get; init; }

    /// <summary>
    /// The name of the response field.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The description of the response field.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// The data type of the response field.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>
    /// The default value of the response field.
    /// </summary>
    [JsonPropertyName("defaultValue")]
    public string? DefaultValue { get; init; }

    /// <summary>
    /// The computed default value of the response field.
    /// </summary>
    [JsonPropertyName("defaultComputedValue")]
    public string? DefaultComputedValue { get; init; }

    /// <summary>
    /// The transformation applied to the response field.
    /// </summary>
    [JsonPropertyName("transform")]
    public string? Transform { get; init; }
}
