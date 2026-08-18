using global::System.Text.Json.Serialization;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

[Serializable]
public record ImportFlowRequest
{
    [JsonPropertyName("flow")]
    public required FlowImportPayload Flow { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
