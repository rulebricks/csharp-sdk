using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Execution settings for a condition row.
/// </summary>
[Serializable]
public record RuleImportRowSettings : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Whether this row is active.
    /// </summary>
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    /// <summary>
    /// Optional group ID for grouped aggregation.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; }

    /// <summary>
    /// Row priority when multiple rows match.
    /// </summary>
    [JsonPropertyName("priority")]
    public required double Priority { get; set; }

    /// <summary>
    /// Optional schedule constraints for this row.
    /// </summary>
    [JsonPropertyName("schedule")]
    public IEnumerable<Dictionary<string, object?>> Schedule { get; set; } =
        new List<Dictionary<string, object?>>();

    /// <summary>
    /// When true, request cells in this row are evaluated with OR semantics.
    /// </summary>
    [JsonPropertyName("or")]
    public bool? Or { get; set; }

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
