using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record GetContextsRequest
{
    /// <summary>
    /// The unique slug for the context.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    /// <summary>
    /// The unique identifier for the context instance.
    /// </summary>
    [JsonIgnore]
    public required string Instance { get; set; }

    /// <summary>
    /// Select comma-separated fields; `context` is always returned. Default: state and execution summaries. Opt-ins: `executions` (GET last-run metadata), `execution_results` (POST `cascaded[].result`). Unavailable fields are omitted; relations require `include_relations`. History: `/history`. Fields: positions, is_new, status, have, need, state, derived, expires_at, created_at, updated_at, executions, executed, triggered, reason, cascaded, relations, execution_results.
    /// </summary>
    [JsonIgnore]
    public string? Include { get; set; }

    /// <summary>
    /// Include named relationships under `relations` (comma-separated; `*` for all). `has_many` returns a list; `has_one`/`belongs_to` return one state or null. Omitted by default.
    /// </summary>
    [JsonIgnore]
    public string? IncludeRelations { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
