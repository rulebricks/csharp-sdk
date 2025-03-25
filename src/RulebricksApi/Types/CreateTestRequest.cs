using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record CreateTestRequest
{
    /// <summary>
    /// The name of the test.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The request object for the test.
    /// </summary>
    [JsonPropertyName("request")]
    public object Request { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// The expected response object for the test.
    /// </summary>
    [JsonPropertyName("response")]
    public object Response { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Indicates whether the test is critical.
    /// </summary>
    [JsonPropertyName("critical")]
    public required bool Critical { get; set; }

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
