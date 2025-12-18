using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record UsageStatistics : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The current plan of the organization.
    /// </summary>
    [JsonPropertyName("plan")]
    public string? Plan { get; set; }

    /// <summary>
    /// The start date of the current monthly period.
    /// </summary>
    [JsonPropertyName("monthly_period_start")]
    public string? MonthlyPeriodStart { get; set; }

    /// <summary>
    /// The end date of the current monthly period.
    /// </summary>
    [JsonPropertyName("monthly_period_end")]
    public string? MonthlyPeriodEnd { get; set; }

    /// <summary>
    /// The number of rule executions used this month.
    /// </summary>
    [JsonPropertyName("monthly_executions_usage")]
    public double? MonthlyExecutionsUsage { get; set; }

    /// <summary>
    /// The total number of rule executions allowed this month.
    /// </summary>
    [JsonPropertyName("monthly_executions_limit")]
    public double? MonthlyExecutionsLimit { get; set; }

    /// <summary>
    /// The number of rule executions remaining this month.
    /// </summary>
    [JsonPropertyName("monthly_executions_remaining")]
    public double? MonthlyExecutionsRemaining { get; set; }

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
