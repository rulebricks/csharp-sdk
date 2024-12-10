namespace RulebricksApi;

public record ListRulesRequest
{
    /// <summary>
    /// Filter rules by folder name or folder ID
    /// </summary>
    public string? Folder { get; init; }
}
