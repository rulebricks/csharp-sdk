using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ListResponseItem
{
    /// <summary>
    /// The unique identifier for the rule.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The name of the rule.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The description of the rule.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Whether the rule is published.
    /// </summary>
    [JsonPropertyName("published")]
    public bool? Published { get; init; }

    /// <summary>
    /// The unique slug for the rule used in API requests.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    /// <summary>
    /// The date this rule was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }
}
