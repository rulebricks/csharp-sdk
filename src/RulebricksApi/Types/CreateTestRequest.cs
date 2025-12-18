using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record CreateTestRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the test.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The request object for the test.
    /// </summary>
    [JsonPropertyName("request")]
    public Dictionary<string, object?> Request { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// The expected response object for the test.
    /// </summary>
    [JsonPropertyName("response")]
    public Dictionary<string, object?> Response { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Indicates whether the test is critical.
    /// </summary>
    [JsonPropertyName("critical")]
    public required bool Critical { get; set; }

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
