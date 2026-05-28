using RulebricksApi.Core;

namespace RulebricksApi.Tests;

public partial class TestsClient : ITestsClient
{
    private readonly RawClient _client;

    internal TestsClient(RawClient client)
    {
        _client = client;
        Rules = new RulesClient(_client);
        Flows = new FlowsClient(_client);
    }

    public IRulesClient Rules { get; }

    public IFlowsClient Flows { get; }
}
