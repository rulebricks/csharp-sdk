using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record ValuesListRequest
{
    /// <summary>
    /// Query all dynamic values containing a specific name
    /// </summary>
    [JsonIgnore]
    public string? Name { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
