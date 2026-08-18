using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Summary counts returned by value writes when the workspace catalog is too large to echo back in full.
/// </summary>
[Serializable]
public record UpdateValuesSummaryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of new values created in this call.
    /// </summary>
    [JsonPropertyName("created")]
    public int? Created { get; set; }

    /// <summary>
    /// Number of existing values updated in this call.
    /// </summary>
    [JsonPropertyName("updated")]
    public int? Updated { get; set; }

    /// <summary>
    /// Total number of values processed in this call.
    /// </summary>
    [JsonPropertyName("processed")]
    public int? Processed { get; set; }

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
