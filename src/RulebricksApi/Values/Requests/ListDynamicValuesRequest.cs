namespace RulebricksApi;

public record ListDynamicValuesRequest
{
    /// <summary>
    /// Name of a specific dynamic value to retrieve data for
    /// </summary>
    public string? Name { get; init; }
}
