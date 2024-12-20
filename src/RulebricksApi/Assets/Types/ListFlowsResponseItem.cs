using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record ListFlowsResponseItem
{
    /// <summary>
    /// The unique identifier for the flow.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The name of the flow.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The description of the flow.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>
    /// Whether the flow is published.
    /// </summary>
    [JsonPropertyName("published")]
    public bool? Published { get; init; }

    /// <summary>
    /// The unique slug for the flow used in API requests.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    /// <summary>
    /// The date this flow was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; init; }
}
