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
}
