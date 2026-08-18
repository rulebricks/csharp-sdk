using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Result of deleting a vocabulary value, including value-to-value reference effects.
/// </summary>
[Serializable]
public record DeleteValueResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Human-readable confirmation.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Values that were deleted with the target because their entire payload referenced it.
    /// </summary>
    [JsonPropertyName("cascade_deleted")]
    public IEnumerable<DeleteValueResponseCascadeDeletedItem>? CascadeDeleted { get; set; }

    /// <summary>
    /// List values that lost item(s) referencing the deleted value but were otherwise kept.
    /// </summary>
    [JsonPropertyName("updated_list_values")]
    public IEnumerable<DeleteValueResponseUpdatedListValuesItem>? UpdatedListValues { get; set; }

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
