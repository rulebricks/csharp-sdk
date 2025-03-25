using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record DeleteDynamicValueRequest
{
    /// <summary>
    /// ID of the dynamic value to delete
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
