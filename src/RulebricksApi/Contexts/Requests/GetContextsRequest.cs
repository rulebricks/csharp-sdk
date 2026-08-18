using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

[Serializable]
public record GetContextsRequest
{
    /// <summary>
    /// The unique slug for the context.
    /// </summary>
    [JsonIgnore]
    public required string Slug { get; set; }

    /// <summary>
    /// The unique identifier for the context instance.
    /// </summary>
    [JsonIgnore]
    public required string Instance { get; set; }

    /// <summary>
    /// Comma-separated relationship names to include in the response under a 'relations' key (has_many relations return a list of related instance states; has_one/belongs_to return a single state or null). Use '*' for all relationships. Omitted by default - related instances are never fetched into the payload unrequested.
    /// </summary>
    [JsonIgnore]
    public string? IncludeRelations { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
