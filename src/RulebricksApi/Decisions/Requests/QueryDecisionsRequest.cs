using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record QueryDecisionsRequest
{
    /// <summary>
    /// Decision data query language expression to filter logs by request/response data. Supports field comparisons (`field=value`, `field&gt;10`), contains (`field:text`), not-contains (`field!:text`), boolean operators (`AND`, `OR`), and parentheses.
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <summary>
    /// Comma-separated list of rule names to filter logs by.
    /// </summary>
    [JsonIgnore]
    public string? Rules { get; set; }

    /// <summary>
    /// Comma-separated list of HTTP status codes to filter logs by.
    /// </summary>
    [JsonIgnore]
    public string? Statuses { get; set; }

    /// <summary>
    /// Start date for the query range (ISO8601 format).
    /// </summary>
    [JsonIgnore]
    public DateTime? Start { get; set; }

    /// <summary>
    /// End date for the query range (ISO8601 format).
    /// </summary>
    [JsonIgnore]
    public DateTime? End { get; set; }

    /// <summary>
    /// Cursor for pagination (returned from previous query).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Number of results to return per page (default: 100).
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// If set to 'true', returns only the count of matching logs instead of the log data.
    /// </summary>
    [JsonIgnore]
    public QueryDecisionsRequestCount? Count { get; set; }

    /// <summary>
    /// (Deprecated) Legacy parameter for filtering by rule slug. Use 'rules' parameter instead.
    /// </summary>
    [JsonIgnore]
    public string? Slug { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
