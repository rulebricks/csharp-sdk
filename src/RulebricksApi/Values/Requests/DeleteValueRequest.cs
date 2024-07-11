namespace RulebricksApi;

public record DeleteValueRequest
{
    /// <summary>
    /// ID of the dynamic value to delete
    /// </summary>
    public required string Id { get; init; }
}
