using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Rule/flow execution log entry with request, response, and decision details.
/// </summary>
[Serializable]
public record DecisionLog : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When the rule/flow was executed.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTime? Timestamp { get; set; }

    /// <summary>
    /// Name of the rule or flow that was executed.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// API endpoint that was called.
    /// </summary>
    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    /// <summary>
    /// HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status")]
    public int? Status { get; set; }

    /// <summary>
    /// The request payload sent to the rule/flow.
    /// </summary>
    [JsonPropertyName("request")]
    public Dictionary<string, object?>? Request { get; set; }

    /// <summary>
    /// The response payload returned by the rule/flow.
    /// </summary>
    [JsonPropertyName("response")]
    public Dictionary<string, object?>? Response { get; set; }

    /// <summary>
    /// Decision details including matched conditions, rows, and evaluation metadata.
    /// </summary>
    [JsonPropertyName("decision")]
    public Dictionary<string, object?>? Decision { get; set; }

    /// <summary>
    /// Error message if the execution failed.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// Whether the request/response data was truncated due to size limits.
    /// </summary>
    [JsonPropertyName("abbreviated")]
    public bool? Abbreviated { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
