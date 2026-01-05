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
    /// Whether the import completed successfully.
    /// </summary>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }

    /// <summary>
    /// Assets that were created during import.
    /// </summary>
    [JsonPropertyName("created")]
    public IEnumerable<ImportManifestResponseCreatedItem>? Created { get; set; }

    /// <summary>
    /// Assets that were updated during import.
    /// </summary>
    [JsonPropertyName("updated")]
    public IEnumerable<ImportManifestResponseUpdatedItem>? Updated { get; set; }

    /// <summary>
    /// Assets that were skipped during import.
    /// </summary>
    [JsonPropertyName("skipped")]
    public IEnumerable<ImportManifestResponseSkippedItem>? Skipped { get; set; }

    /// <summary>
    /// Any errors encountered during import.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<ImportManifestResponseErrorsItem>? Errors { get; set; }

    /// <summary>
    /// Non-fatal warnings from import validation.
    /// </summary>
    [JsonPropertyName("warnings")]
    public IEnumerable<string>? Warnings { get; set; }

    /// <summary>
    /// IDs of any organizational folders created during import.
    /// </summary>
    [JsonPropertyName("organization_created")]
    public ImportManifestResponseOrganizationCreated? OrganizationCreated { get; set; }

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
