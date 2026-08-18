using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record UpsertObjectRequest
{
    /// <summary>
    /// Object ID to update. Omit to resolve by name (creating the object when the name is new).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Object name. Required when ID is omitted; used to resolve the existing object or to name a new one.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The object's JSON Schema as a string. Enums in the schema become the object's managed values.
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; set; }

    /// <summary>
    /// User groups for the object, propagated to every value it generates. Omit to keep the current groups.
    /// </summary>
    [JsonPropertyName("user_groups")]
    public IEnumerable<string>? UserGroups { get; set; }

    /// <summary>
    /// Preview the value diff (would_sync / would_archive) without writing anything.
    /// </summary>
    [JsonPropertyName("dry_run")]
    public bool? DryRun { get; set; }

    /// <summary>
    /// Optimistic concurrency: reject with 409 when the object's updated_at no longer matches.
    /// </summary>
    [JsonPropertyName("expected_updated_at")]
    public string? ExpectedUpdatedAt { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
