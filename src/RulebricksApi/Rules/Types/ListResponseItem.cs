using System.Text.Json.Serialization;
using RulebricksApi;

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
    /// The creation date of the rule.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; init; }

    /// <summary>
    /// The unique slug for the rule used in API requests.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonPropertyName("request_schema")]
    public IEnumerable<ListResponseItemRequestSchemaItem>? RequestSchema { get; init; }

    [JsonPropertyName("response_schema")]
    public IEnumerable<ListResponseItemResponseSchemaItem>? ResponseSchema { get; init; }
}
