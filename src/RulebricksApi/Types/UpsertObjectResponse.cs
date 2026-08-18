using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record UpsertObjectResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// True when the object was created by this call.
    /// </summary>
    [JsonPropertyName("created")]
    public bool? Created { get; set; }

    [JsonPropertyName("object")]
    public WorkspaceObject? Object { get; set; }

    /// <summary>
    /// Managed-value sync results (or would_sync / would_archive for dry runs).
    /// </summary>
    [JsonPropertyName("values")]
    public UpsertObjectResponseValues? Values { get; set; }

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
