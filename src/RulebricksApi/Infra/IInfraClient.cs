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
    /// Pre-scales the deployment's solver fleet to its maximum capacity ahead of a large batch workload, so the first wave of requests never pays the scale-from-baseline window. Takes no request body: the target is always the deployment's own configured ceiling. The fleet stays warm for a bounded window (default 10 minutes; repeat calls refresh it), after which normal autoscaling reclaims the capacity - an unused warm-up costs at most that window. Poll the GET variant until `status` is `ready` before starting the batch. Self-hosted deployments only.
    /// </summary>
    WithRawResponseTask<ScaleStatusResponse> ScaleAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
