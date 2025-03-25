using RulebricksApi.Core;

namespace RulebricksApi.Tests;

public partial class TestsClient
{
    private RawClient _client;

    internal TestsClient(RawClient client)
    {
        _client = client;
        Rules = new RulesClient(_client);
        Flows = new FlowsClient(_client);
    }

    public RulesClient Rules { get; }

    public FlowsClient Flows { get; }
}
