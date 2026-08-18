using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record RunTestsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The slug of the rule that was tested (rule runs only).
    /// </summary>
    [JsonPropertyName("rule")]
    public string? Rule { get; set; }

    /// <summary>
    /// The slug of the flow that was tested (flow runs only).
    /// </summary>
    [JsonPropertyName("flow")]
    public string? Flow { get; set; }

    /// <summary>
    /// The number of tests that were run.
    /// </summary>
    [JsonPropertyName("total")]
    public required int Total { get; set; }

    /// <summary>
    /// The number of tests that passed.
    /// </summary>
    [JsonPropertyName("passed")]
    public required int Passed { get; set; }

    /// <summary>
    /// The number of tests that failed.
    /// </summary>
    [JsonPropertyName("failed")]
    public required int Failed { get; set; }

    /// <summary>
    /// The percentage of tests that passed, formatted to two decimals.
    /// </summary>
    [JsonPropertyName("pass_percentage")]
    public required string PassPercentage { get; set; }

    /// <summary>
    /// True if any test flagged as critical failed. Use this to decide whether to block a release.
    /// </summary>
    [JsonPropertyName("critical_failure")]
    public required bool CriticalFailure { get; set; }

    /// <summary>
    /// The names of all tests that failed.
    /// </summary>
    [JsonPropertyName("failed_tests")]
    public IEnumerable<string> FailedTests { get; set; } = new List<string>();

    /// <summary>
    /// The names of the critical tests that failed.
    /// </summary>
    [JsonPropertyName("critical_failed_tests")]
    public IEnumerable<string> CriticalFailedTests { get; set; } = new List<string>();

    /// <summary>
    /// Per-test outcomes.
    /// </summary>
    [JsonPropertyName("results")]
    public IEnumerable<RunTestsResponseResultsItem> Results { get; set; } =
        new List<RunTestsResponseResultsItem>();

    /// <summary>
    /// Diagnostics for each failing test: what was expected, what the rule/flow actually produced, and (for rules) which decision-table row(s) fired. Empty when every test passed.
    /// </summary>
    [JsonPropertyName("failures")]
    public IEnumerable<RunTestsResponseFailuresItem>? Failures { get; set; }

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
