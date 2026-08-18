using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record RunTestsResponseFailuresItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("critical")]
    public required bool Critical { get; set; }

    /// <summary>
    /// The expected response for the test case.
    /// </summary>
    [JsonPropertyName("expected")]
    public object? Expected { get; set; }

    /// <summary>
    /// The response the rule/flow actually produced (null when the case failed to execute).
    /// </summary>
    [JsonPropertyName("actual")]
    public object? Actual { get; set; }

    /// <summary>
    /// Rules only: the index(es) of the decision-table row(s) that fired for this case.
    /// </summary>
    [JsonPropertyName("matched_rows")]
    public IEnumerable<int>? MatchedRows { get; set; }

    /// <summary>
    /// A human-readable evaluation error when the case failed to execute.
    /// </summary>
    [JsonPropertyName("error_message")]
    public string? ErrorMessage { get; set; }

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
