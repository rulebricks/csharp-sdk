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
    /// Comma-separated list of per-instance fields to include in results (instance_id is always present). Omit to include everything. Valid fields: positions, is_new, status, have, need, state, expires_at, executions, executed, triggered, reason. Useful for keeping response size proportional to outcomes rather than data volume, e.g. include=status,executed.
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
