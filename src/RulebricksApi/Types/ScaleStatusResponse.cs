using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using RulebricksApi.Core;

namespace RulebricksApi;

/// <summary>
/// Solver fleet warm-up status (self-hosted deployments). Poll GET /scale until `status` is `ready` before starting a large batch workload.
/// </summary>
[Serializable]
public record ScaleStatusResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// `idle`: no warm-up is active. `scaling`: a warm-up is active and workers are still joining. `ready`: the active worker count reached the target.
    /// </summary>
    [JsonPropertyName("status")]
    public required ScaleStatusResponseStatus Status { get; set; }

    /// <summary>
    /// Solvers currently joined to the processing group and able to accept work. Null when the deployment runs without a message broker (no autoscaling).
    /// </summary>
    [JsonPropertyName("active_workers")]
    public int? ActiveWorkers { get; set; }

    /// <summary>
    /// The fleet ceiling a warm-up scales toward - a function of the deployment's configuration, never caller input.
    /// </summary>
    [JsonPropertyName("target_workers")]
    public required int TargetWorkers { get; set; }

    /// <summary>
    /// Seconds until the active warm-up lapses and normal autoscaling reclaims the capacity. 0 when idle. Repeat POST /scale calls refresh the window.
    /// </summary>
    [JsonPropertyName("expires_in_seconds")]
    public required int ExpiresInSeconds { get; set; }

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
