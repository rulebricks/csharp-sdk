namespace RulebricksApi;

public record DeleteDynamicValueRequest
{
    /// <summary>
    /// ID of the dynamic value to delete
    /// </summary>
    public required string Id { get; init; }
}
