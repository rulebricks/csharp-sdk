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
    /// Indicates if the test resulted in an error. Null if test has not been executed.
    /// </summary>
    [JsonPropertyName("error")]
    public bool? Error { get; set; }

    /// <summary>
    /// Indicates if the test was successful. Null if test has not been executed.
    /// </summary>
    [JsonPropertyName("success")]
    public bool? Success { get; set; }

    /// <summary>
    /// The state of the test after execution.
    /// </summary>
    [JsonPropertyName("test_state")]
    public TestTestState? TestState { get; set; }

    /// <summary>
    /// The timestamp when the test was last executed.
    /// </summary>
    [JsonPropertyName("last_executed")]
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
