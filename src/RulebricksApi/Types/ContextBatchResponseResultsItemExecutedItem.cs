using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record ContextBatchResponseResultsItemExecutedItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("type")]
    public ContextBatchResponseResultsItemExecutedItemType? Type { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("status")]
    public ContextBatchResponseResultsItemExecutedItemStatus? Status { get; set; }

    /// <summary>
    /// Flow entries only: the run's execution ID, accepted by `/decisions/query` `trace`.
    /// </summary>
    [JsonPropertyName("execution_id")]
    public string? ExecutionId { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    /// <summary>
    /// Full execution result, present only when include contains execution_results. May be large.
    /// </summary>
    [JsonPropertyName("result")]
    public object? Result { get; set; }

    [JsonPropertyName("written_to_context")]
    public IEnumerable<string>? WrittenToContext { get; set; }

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
