using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Rulebricks Flow Schema definition accepted by /admin/flows/import. If `id` is provided the matching flow is updated; otherwise a new flow is created. The server expands this into the full flow graph and (unless `_publish` is false) publishes it so it is immediately executable.
/// </summary>
[Serializable]
public record FlowImportPayload : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Flow name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Optional flow description.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The flow's nodes. Exactly one must be an `origin`.
    /// </summary>
    [JsonPropertyName("nodes")]
    public IEnumerable<RulebricksFlowNode> Nodes { get; set; } = new List<RulebricksFlowNode>();

    /// <summary>
    /// Property and control connections between node refs.
    /// </summary>
    [JsonPropertyName("connections")]
    public IEnumerable<RulebricksFlowConnection>? Connections { get; set; }

    /// <summary>
    /// Whether to publish the flow on import (default true). Set false to import as a draft.
    /// </summary>
    [JsonPropertyName("_publish")]
    public bool? Publish { get; set; }

    /// <summary>
    /// Provide an existing flow UUID to update it instead of creating a new flow.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Stable ID used for import round-tripping.
    /// </summary>
    [JsonPropertyName("stable_id")]
    public string? StableId { get; set; }

    /// <summary>
    /// Optional slug (auto-generated when omitted).
    /// </summary>
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
