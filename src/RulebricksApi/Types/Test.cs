using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record Test : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the test.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

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

    /// <summary>
    /// Indicates if the test resulted in an error.
    /// </summary>
    [JsonPropertyName("error")]
    public required bool Error { get; set; }

    /// <summary>
    /// Indicates if the test was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; set; }

    /// <summary>
    /// The state of the test after execution.
    /// </summary>
    [JsonPropertyName("testState")]
    public TestTestState? TestState { get; set; }

    /// <summary>
    /// The timestamp when the test was last executed.
    /// </summary>
    [JsonPropertyName("lastExecuted")]
    public DateTime? LastExecuted { get; set; }

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
