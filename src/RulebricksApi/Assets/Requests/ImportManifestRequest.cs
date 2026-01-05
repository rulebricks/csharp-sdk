using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ImportManifestRequest
{
    /// <summary>
    /// The RBM manifest object containing assets to import.
    /// </summary>
    [JsonPropertyName("manifest")]
    public required ImportManifestRequestManifest Manifest { get; set; }

    /// <summary>
    /// How to handle conflicts with existing assets. 'update' overwrites, 'skip' ignores, 'error' fails.
    /// </summary>
    [JsonPropertyName("conflict_strategy")]
    public ImportManifestRequestConflictStrategy? ConflictStrategy { get; set; }

    /// <summary>
    /// Optional folder name to place imported assets into. Created if it doesn't exist.
    /// </summary>
    [JsonPropertyName("target_folder_name")]
    public string? TargetFolderName { get; set; }

    /// <summary>
    /// Optional mapping for legacy flow imports to reuse existing rules.
    /// </summary>
    [JsonPropertyName("legacy_rule_mapping")]
    public Dictionary<
        string,
        ImportManifestRequestLegacyRuleMappingValue
    >? LegacyRuleMapping { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
