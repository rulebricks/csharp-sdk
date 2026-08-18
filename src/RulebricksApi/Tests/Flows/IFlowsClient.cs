using RulebricksApi;

namespace RulebricksApi.Tests;

public partial interface IFlowsClient
{
    /// <summary>
    /// Retrieves a list of tests associated with the flow identified by the slug.
    /// </summary>
    WithRawResponseTask<IEnumerable<RulebricksApi.Test>> ListAsync(
        ListFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a new test to the test suite of a flow identified by the slug.
    /// </summary>
    WithRawResponseTask<RulebricksApi.Test> CreateAsync(
        CreateFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a test from the test suite of a flow identified by the slug.
    /// </summary>
    WithRawResponseTask<RulebricksApi.Test> DeleteAsync(
        DeleteFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Executes every test in the flow's test suite (or only the critical tests when `critical_only` is true) against the flow's current graph and returns a summary of which passed, which failed, and whether any CRITICAL test failed. Tests always run against the latest draft of the flow; version targeting does not apply.
    /// </summary>
    WithRawResponseTask<RunTestsResponse> RunAsync(
        RunFlowsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
