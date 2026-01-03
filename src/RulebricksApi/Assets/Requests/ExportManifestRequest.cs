using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ExportManifestRequest
{
    /// <summary>
    /// Rule IDs or slugs to export.
    /// </summary>
    [JsonPropertyName("rules")]
    public IEnumerable<string>? Rules { get; set; }

    /// <summary>
    /// Flow IDs or slugs to export.
    /// </summary>
    [JsonPropertyName("flows")]
    public IEnumerable<string>? Flows { get; set; }

    /// <summary>
    /// Context IDs or slugs to export.
    /// </summary>
    [JsonPropertyName("contexts")]
    public IEnumerable<string>? Contexts { get; set; }

    /// <summary>
    /// Value IDs or names to export.
    /// </summary>
    [JsonPropertyName("values")]
    public IEnumerable<string>? Values { get; set; }

    /// <summary>
    /// Export all assets of specified types.
    /// </summary>
    [JsonPropertyName("includeAll")]
    public bool? IncludeAll { get; set; }

    /// <summary>
    /// Return a preview of what would be exported without the full data.
    /// </summary>
    [JsonPropertyName("preview")]
    public bool? Preview { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
