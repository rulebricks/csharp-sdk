using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

public record ExportRuleRequest
{
    /// <summary>
    /// The ID of the rule to export.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
