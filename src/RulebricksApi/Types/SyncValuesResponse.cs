using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Result of a sync call. For dry runs, counts describe what would happen.
/// </summary>
[Serializable]
public record SyncValuesResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("collection")]
    public string? Collection { get; set; }

    /// <summary>
    /// Echoed for chunked runs.
    /// </summary>
    [JsonPropertyName("sync_id")]
    public string? SyncId { get; set; }

    /// <summary>
    /// Present (true) when a finalize call was retried after the run already completed; the body replays the recorded result and no second sweep ran.
    /// </summary>
    [JsonPropertyName("already_completed")]
    public bool? AlreadyCompleted { get; set; }

    [JsonPropertyName("dry_run")]
    public bool? DryRun { get; set; }

    /// <summary>
    /// Whether the removal sweep ran (single-request syncs and completing calls of chunked runs).
    /// </summary>
    [JsonPropertyName("swept")]
    public bool? Swept { get; set; }

    /// <summary>
    /// Values created by this call.
    /// </summary>
    [JsonPropertyName("created")]
    public int? Created { get; set; }

    /// <summary>
    /// Existing values whose content changed.
    /// </summary>
    [JsonPropertyName("updated")]
    public int? Updated { get; set; }

    /// <summary>
    /// Values in the payload that already matched (no write, no history entry).
    /// </summary>
    [JsonPropertyName("unchanged")]
    public int? Unchanged { get; set; }

    /// <summary>
    /// Total values in this call's payload.
    /// </summary>
    [JsonPropertyName("processed")]
    public int? Processed { get; set; }

    /// <summary>
    /// Values under the collection that were archived because the desired state no longer contains them (includes blocked hard-deletes).
    /// </summary>
    [JsonPropertyName("archived")]
    public int? Archived { get; set; }

    /// <summary>
    /// Values permanently deleted (permanently_delete: true only).
    /// </summary>
    [JsonPropertyName("deleted")]
    public int? Deleted { get; set; }

    /// <summary>
    /// Hard-deletes that were archived instead because the value is still referenced. Capped at 200 entries.
    /// </summary>
    [JsonPropertyName("blocked")]
    public IEnumerable<SyncValuesResponseBlockedItem>? Blocked { get; set; }

    /// <summary>
    /// Rows the sync refused to touch (e.g. values managed by a workspace object). Capped at 200 entries.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<SyncValuesResponseErrorsItem>? Errors { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
