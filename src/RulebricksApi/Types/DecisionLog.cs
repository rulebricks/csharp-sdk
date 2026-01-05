using System.Text.Json.Serialization;
using OneOf;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Rule/flow execution log entry with request, response, and decision details.
/// </summary>
[Serializable]
public record DecisionLog : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

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
    /// The request payload sent to the rule/flow. Can be an object for single requests or an array for bulk operations.
    /// </summary>
    [JsonPropertyName("request")]
    public OneOf<
        Dictionary<string, object?>,
        IEnumerable<Dictionary<string, object?>>
    >? Request { get; set; }

    /// <summary>
    /// The response payload returned by the rule/flow. Can be an object for single responses or an array for bulk operations.
    /// </summary>
    [JsonPropertyName("response")]
    public DecisionLogResponse? Response { get; set; }

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
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
