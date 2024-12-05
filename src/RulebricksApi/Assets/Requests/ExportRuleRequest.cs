namespace RulebricksApi;

public record ExportRuleRequest
{
    /// <summary>
    /// The ID of the rule to export.
    /// </summary>
    public required string Id { get; init; }
}
