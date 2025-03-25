using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record ListDynamicValuesRequest
{
    /// <summary>
    /// Name of a specific dynamic value to retrieve data for
    /// </summary>
    [JsonIgnore]
    public string? Name { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
