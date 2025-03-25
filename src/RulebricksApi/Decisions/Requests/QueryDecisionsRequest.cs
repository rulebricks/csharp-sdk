using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record QueryDecisionsRequest
{
    /// <summary>
    /// The slug of the rule to query logs for.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    /// <summary>
    /// Start date for the query range (ISO8601 format).
    /// </summary>
    [JsonIgnore]
    public DateTime? From { get; set; }

    /// <summary>
    /// End date for the query range (ISO8601 format).
    /// </summary>
    [JsonIgnore]
    public DateTime? To { get; set; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Number of results to return per page.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
