using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record UsageStatistics
{
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

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
