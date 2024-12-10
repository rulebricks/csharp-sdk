using System.Text.Json.Serialization;

#nullable enable

namespace RulebricksApi;

public record DeleteFlowTestResponse
{
    /// <summary>
    /// Unique identifier for the test.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

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

    /// <summary>
    /// Indicates if the test resulted in an error.
    /// </summary>
    [JsonPropertyName("error")]
    public required bool Error { get; init; }

    /// <summary>
    /// Indicates if the test was successful.
    /// </summary>
    [JsonPropertyName("success")]
    public required bool Success { get; init; }

    /// <summary>
    /// The state of the test after execution.
    /// </summary>
    [JsonPropertyName("testState")]
    public Dictionary<string, object>? TestState { get; init; }

    /// <summary>
    /// The timestamp when the test was last executed.
    /// </summary>
    [JsonPropertyName("lastExecuted")]
    public DateTime? LastExecuted { get; init; }
}
