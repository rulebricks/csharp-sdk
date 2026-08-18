using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ParallelSolveRequestValue : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Slug of the rule to execute, optionally suffixed with a published version number or release environment slug (e.g. `my-rule`, `my-rule/3`, or `my-rule/production`). A bare slug executes the current published version.
    /// </summary>
    [JsonPropertyName("$rule")]
    public string? Rule { get; set; }

    /// <summary>
    /// Slug of the flow to execute, optionally suffixed with a published version number or release environment slug (e.g. `my-flow`, `my-flow/3`, or `my-flow/production`). A bare slug executes the current published version.
    /// </summary>
    [JsonPropertyName("$flow")]
    public string? Flow { get; set; }

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
