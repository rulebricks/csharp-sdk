using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// A single rule row containing request conditions and response output.
/// </summary>
[Serializable]
public record RuleImportConditionRow : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Request-side cells keyed by request schema field key.
    /// </summary>
    [JsonPropertyName("request")]
    public Dictionary<string, RuleImportRequestCell> Request { get; set; } =
        new Dictionary<string, RuleImportRequestCell>();

    /// <summary>
    /// Response-side cells keyed by response schema field key.
    /// </summary>
    [JsonPropertyName("response")]
    public Dictionary<string, RuleImportResponseCell> Response { get; set; } =
        new Dictionary<string, RuleImportResponseCell>();

    [JsonPropertyName("settings")]
    public required RuleImportRowSettings Settings { get; set; }

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
