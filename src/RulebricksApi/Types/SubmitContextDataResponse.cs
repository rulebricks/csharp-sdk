using System.Text.Json;
using System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Response after submitting data, including any auto-executed evaluations.
/// </summary>
[Serializable]
public record SubmitContextDataResponse : IJsonOnDeserialized
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
    /// The merged state after submitting data and any auto-executed rules/flows.
    /// </summary>
    [JsonPropertyName("state")]
    public Dictionary<string, object?>? State { get; set; }

    /// <summary>
    /// Whether all required fields are present ('complete') or some are missing ('pending').
    /// </summary>
    [JsonPropertyName("status")]
    public SubmitContextDataResponseStatus? Status { get; set; }

    /// <summary>
    /// List of field keys that are currently populated.
    /// </summary>
    [JsonPropertyName("have")]
    public IEnumerable<string>? Have { get; set; }

    /// <summary>
    /// List of required field keys that are still missing.
    /// </summary>
    [JsonPropertyName("need")]
    public IEnumerable<string>? Need { get; set; }

    /// <summary>
    /// Whether this submission created a new instance (true) or updated an existing one (false).
    /// </summary>
    [JsonPropertyName("is_new")]
    public bool? IsNew { get; set; }

    /// <summary>
    /// When the instance will expire based on context TTL.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Results from auto-executed rules/flows and pending evaluation cascades.
    /// </summary>
    [JsonPropertyName("cascaded")]
    public IEnumerable<CascadeResult>? Cascaded { get; set; }

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
