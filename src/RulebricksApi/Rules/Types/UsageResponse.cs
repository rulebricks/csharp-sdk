using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record UsageResponse
{
    /// <summary>
    /// The current plan of the organization.
    /// </summary>
    [JsonPropertyName("plan")]
    public string? Plan { get; init; }

    /// <summary>
    /// The start date of the current monthly period.
    /// </summary>
    [JsonPropertyName("monthly_period_start")]
    public string? MonthlyPeriodStart { get; init; }

    /// <summary>
    /// The end date of the current monthly period.
    /// </summary>
    [JsonPropertyName("monthly_period_end")]
    public string? MonthlyPeriodEnd { get; init; }

    /// <summary>
    /// The number of rule executions used this month.
    /// </summary>
    [JsonPropertyName("monthly_executions_usage")]
    public double? MonthlyExecutionsUsage { get; init; }

    /// <summary>
    /// The total number of rule executions allowed this month.
    /// </summary>
    [JsonPropertyName("monthly_executions_limit")]
    public double? MonthlyExecutionsLimit { get; init; }

    /// <summary>
    /// The number of rule executions remaining this month.
    /// </summary>
    [JsonPropertyName("monthly_executions_remaining")]
    public double? MonthlyExecutionsRemaining { get; init; }
}
