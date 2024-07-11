namespace RulebricksApi;

public record DeleteValueRequest
{
    /// <summary>
    /// ID of the dynamic value to delete
    /// </summary>
    public string Id { get; init; }

    public DeleteValueRequest(string id)
    {
        Id = id;
    }
}
