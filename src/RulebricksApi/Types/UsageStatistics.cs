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
    /// The start date of the current monthly period (MM-DD-YYYY).
    /// </summary>
    [JsonPropertyName("monthly_period_start")]
    public string? MonthlyPeriodStart { get; set; }

    /// <summary>
    /// The end date of the current monthly period (MM-DD-YYYY).
    /// </summary>
    [JsonPropertyName("monthly_period_end")]
    public string? MonthlyPeriodEnd { get; set; }

    /// <summary>
    /// The number of rule executions used this month.
    /// </summary>
    [JsonPropertyName("monthly_executions_usage")]
    public double? MonthlyExecutionsUsage { get; set; }

    /// <summary>
    /// The total number of rule executions allowed this month. -1 indicates unlimited.
    /// </summary>
    [JsonPropertyName("monthly_executions_limit")]
    public double? MonthlyExecutionsLimit { get; set; }

    /// <summary>
    /// The number of rule executions remaining this month. -1 indicates unlimited.
    /// </summary>
    [JsonPropertyName("monthly_executions_remaining")]
    public double? MonthlyExecutionsRemaining { get; set; }

    /// <summary>
    /// Whether the plan has unlimited executions (true when monthly_executions_limit is -1).
    /// </summary>
    [JsonPropertyName("unlimited_plan")]
    public bool? UnlimitedPlan { get; set; }

    /// <summary>
    /// Number of days remaining in the current billing period.
    /// </summary>
    [JsonPropertyName("days_remaining_in_period")]
    public double? DaysRemainingInPeriod { get; set; }

    /// <summary>
    /// Average number of executions per day in the current period.
    /// </summary>
    [JsonPropertyName("daily_average_usage")]
    public double? DailyAverageUsage { get; set; }

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
