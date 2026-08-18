using RulebricksApi;

namespace RulebricksApi.Tests;

public partial interface IRulesClient
{
    /// <summary>
    /// Retrieves a list of tests associated with the rule identified by the slug.
    /// </summary>
    WithRawResponseTask<IEnumerable<RulebricksApi.Test>> ListAsync(
        ListRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a new test to the test suite of a rule identified by the slug.
    /// </summary>
    WithRawResponseTask<RulebricksApi.Test> CreateAsync(
        CreateRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a test from the test suite of a rule identified by the slug.
    /// </summary>
    WithRawResponseTask<RulebricksApi.Test> DeleteAsync(
        DeleteRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Executes every test in the rule's test suite (or only the critical tests when `critical_only` is true) and returns a summary of which passed, which failed, and whether any CRITICAL test failed. Use the `critical_failure` flag as the signal for whether a release should be blocked. Tests always run against the latest draft of the rule; version targeting does not apply.
    /// </summary>
    WithRawResponseTask<RunTestsResponse> RunAsync(
        RunRulesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
