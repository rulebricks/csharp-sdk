using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record SyncValuesRequest
{
    /// <summary>
    /// Collection path to sync (e.g. 'Medical Codes'). Only values under this path are affected.
    /// </summary>
    [JsonPropertyName("collection")]
    public required string Collection { get; set; }

    /// <summary>
    /// Desired members of the collection, keyed relative to the collection path ('A123' becomes 'Medical Codes.A123'). Nested objects flatten with dot notation, and payloads may use ValueReference markers. An empty object empties the collection. May be omitted on a pure finalize call (sync_id + complete).
    /// </summary>
    [JsonPropertyName("values")]
    public Dictionary<string, object?>? Values { get; set; }

    /// <summary>
    /// Identifier for a chunked run. Repeat the call with the same sync_id for each chunk of the desired state; nothing is removed until a call with complete: true. Abandoned runs are purged after 24 hours without removing anything.
    /// </summary>
    [JsonPropertyName("sync_id")]
    public string? SyncId { get; set; }

    /// <summary>
    /// Marks the run as complete, triggering the removal sweep. Implicitly true when sync_id is omitted (single-request syncs), false otherwise.
    /// </summary>
    [JsonPropertyName("complete")]
    public bool? Complete { get; set; }

    /// <summary>
    /// Hard-delete removed values instead of archiving them. Removals still referenced by a rule, flow, or surviving value are archived instead and reported in 'blocked'. Self-hosted deployments retain tombstones regardless.
    /// </summary>
    [JsonPropertyName("permanently_delete")]
    public bool? PermanentlyDelete { get; set; }

    /// <summary>
    /// Compute and return the full diff without writing anything. Only supported for single-request syncs (omit sync_id).
    /// </summary>
    [JsonPropertyName("dry_run")]
    public bool? DryRun { get; set; }

    /// <summary>
    /// Optional array of user group names to assign to written values, matching POST /values.
    /// </summary>
    [JsonPropertyName("user_groups")]
    public IEnumerable<string>? UserGroups { get; set; }

    /// <summary>
    /// Optional metadata keyed by FULL value name (including the collection prefix).
    /// </summary>
    [JsonPropertyName("metadata_by_name")]
    public Dictionary<string, Dictionary<string, object?>>? MetadataByName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
