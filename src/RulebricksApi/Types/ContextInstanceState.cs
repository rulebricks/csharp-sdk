using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// The current state of a context instance.
/// </summary>
[Serializable]
public record ContextInstanceState : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Combined identifier in format 'contextSlug:instanceId'.
    /// </summary>
    [JsonPropertyName("context")]
    public string? Context { get; set; }

    /// <summary>
    /// The current base field values for this instance.
    /// </summary>
    [JsonPropertyName("state")]
    public Dictionary<string, object?>? State { get; set; }

    /// <summary>
    /// Computed/derived field values from bound rules.
    /// </summary>
    [JsonPropertyName("derived")]
    public Dictionary<string, object?>? Derived { get; set; }

    /// <summary>
    /// Whether all required fields are present ('complete') or some are missing ('pending').
    /// </summary>
    [JsonPropertyName("status")]
    public ContextInstanceStateStatus? Status { get; set; }

    /// <summary>
    /// List of field keys that are currently populated.
    /// </summary>
    [JsonPropertyName("have")]
    public IEnumerable<string>? Have { get; set; }

    /// <summary>
    /// List of required field keys that are missing (empty when status is 'complete').
    /// </summary>
    [JsonPropertyName("need")]
    public IEnumerable<string>? Need { get; set; }

    /// <summary>
    /// When the instance was first created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// When the instance was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// When the instance will expire based on context TTL.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

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
