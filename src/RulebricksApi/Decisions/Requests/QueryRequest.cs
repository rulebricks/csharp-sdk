namespace RulebricksApi;

public record QueryRequest
{
    /// <summary>
    /// The slug of the rule to query logs for.
    /// </summary>
    public required string Slug { get; init; }

    /// <summary>
    /// Start date for the query range (ISO8601 format).
    /// </summary>
    public DateTime? From { get; init; }

    /// <summary>
    /// End date for the query range (ISO8601 format).
    /// </summary>
    public DateTime? To { get; init; }

    /// <summary>
    /// Cursor for pagination.
    /// </summary>
    public string? Cursor { get; init; }

    /// <summary>
    /// Number of results to return per page.
    /// </summary>
    public int? Limit { get; init; }
}
