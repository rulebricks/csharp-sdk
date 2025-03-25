using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi.Assets;

public record RulesListRequest
{
    /// <summary>
    /// Filter rules by folder name or folder ID
    /// </summary>
    [JsonIgnore]
    public string? Folder { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
