using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Managed-value sync results (or would_sync / would_archive for dry runs).
/// </summary>
[Serializable]
public record UpsertObjectResponseValues : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Managed values created or updated.
    /// </summary>
    [JsonPropertyName("synced")]
    public int? Synced { get; set; }

    /// <summary>
    /// Previously generated values archived because the schema no longer declares them.
    /// </summary>
    [JsonPropertyName("archived")]
    public int? Archived { get; set; }

    /// <summary>
    /// Dry run: managed values that would be synced.
    /// </summary>
    [JsonPropertyName("would_sync")]
    public int? WouldSync { get; set; }

    /// <summary>
    /// Dry run: values that would be archived.
    /// </summary>
    [JsonPropertyName("would_archive")]
    public IEnumerable<UpsertObjectResponseValuesWouldArchiveItem>? WouldArchive { get; set; }

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
