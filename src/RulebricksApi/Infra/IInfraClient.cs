namespace RulebricksApi;

public partial interface IInfraClient
{
    /// <summary>
    /// Reports the fleet scale-up state. Worker counts reflect solvers that have actually joined the processing group and can accept work. Self-hosted deployments only.
    /// </summary>
    WithRawResponseTask<ScaleStatusResponse> StatusAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Scales up the deployment's solver fleet to its maximum capacity ahead of a known incoming batch workload. Usually takes 1-2 minutes to complete. This is completely optional, the solver fleet will scale up automatically as needed anyway. Self-hosted deployments only.
    /// </summary>
    WithRawResponseTask<ScaleStatusResponse> ScaleAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
