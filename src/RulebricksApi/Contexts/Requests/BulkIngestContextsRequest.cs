using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record BulkIngestContextsRequest
{
    /// <summary>
    /// The unique slug for the context.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    /// <summary>
    /// Select comma-separated fields; `instance_id` is always returned. Default: state and execution summaries. Opt-ins: `executions` (stored metadata), `execution_results` (`executed[].result`). Compact outcomes with flow IDs: `status,triggered,executed`. Unavailable fields are omitted. History: `/history`. Fields: positions, is_new, status, have, need, state, derived, expires_at, created_at, updated_at, executions, executed, triggered, reason, cascaded, relations, execution_results.
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    [JsonIgnore]
    public IEnumerable<Dictionary<string, object?>> Body { get; set; } =
        new List<Dictionary<string, object?>>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
