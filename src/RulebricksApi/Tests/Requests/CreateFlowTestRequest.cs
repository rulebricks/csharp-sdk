using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record CreateFlowTestRequest
{
    /// <summary>
    /// The name of the test.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The request object for the test.
    /// </summary>
    [JsonPropertyName("request")]
    public Dictionary<string, object> Request { get; init; } = new Dictionary<string, object>();

    /// <summary>
    /// The expected response object for the test.
    /// </summary>
    [JsonPropertyName("response")]
    public Dictionary<string, object> Response { get; init; } = new Dictionary<string, object>();

    /// <summary>
    /// Indicates whether the test is critical.
    /// </summary>
    [JsonPropertyName("critical")]
    public required bool Critical { get; init; }
}
