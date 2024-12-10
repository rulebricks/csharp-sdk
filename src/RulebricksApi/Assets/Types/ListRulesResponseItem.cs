using System.Text.Json.Serialization;
using RulebricksApi;

#nullable enable

namespace RulebricksApi;

public record ListRulesResponseItem
{
    /// <summary>
    /// The unique identifier for the rule.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// The date this rule was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; init; }

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
    /// The unique slug for the rule used in API requests.
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    /// <summary>
    /// The folder containing this rule
    /// </summary>
    [JsonPropertyName("folder")]
    public ListRulesResponseItemFolder? Folder { get; init; }

    /// <summary>
    /// The published request schema for the rule.
    /// </summary>
    [JsonPropertyName("request_schema")]
    public Dictionary<string, object>? RequestSchema { get; init; }

    /// <summary>
    /// The published response schema for the rule.
    /// </summary>
    [JsonPropertyName("response_schema")]
    public Dictionary<string, object>? ResponseSchema { get; init; }
}
