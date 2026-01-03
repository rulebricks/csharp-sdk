using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ImportManifestResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Success message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Count of imported assets by type.
    /// </summary>
    [JsonPropertyName("imported")]
    public ImportManifestResponseImported? Imported { get; set; }

    /// <summary>
    /// Count of skipped assets by type (already exist and overwrite=false).
    /// </summary>
    [JsonPropertyName("skipped")]
    public ImportManifestResponseSkipped? Skipped { get; set; }

    /// <summary>
    /// Any errors encountered during import.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<ImportManifestResponseErrorsItem>? Errors { get; set; }

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
