using RulebricksApi;
using RulebricksApi.Core;

#nullable enable

namespace RulebricksApi;

public partial class RulebricksApiClient
{
    private RawClient _client;

    public RulebricksApiClient(string? apiKey = null, ClientOptions? clientOptions = null)
    {
        _client = new RawClient(
            new Dictionary<string, string>()
            {
                { "x-api-key", apiKey ?? string.Empty },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "RulebricksApi" },
                { "X-Fern-SDK-Version", "0.0.107" },
            },
            clientOptions ?? new ClientOptions()
        );
        Rules = new RulesClient(_client);
        Flows = new FlowsClient(_client);
        Decisions = new DecisionsClient(_client);
        Assets = new AssetsClient(_client);
        Users = new UsersClient(_client);
        Tests = new TestsClient(_client);
        Values = new ValuesClient(_client);
    }

    public RulesClient Rules { get; init; }

    public FlowsClient Flows { get; init; }

    public DecisionsClient Decisions { get; init; }

    public AssetsClient Assets { get; init; }

    public UsersClient Users { get; init; }

    public TestsClient Tests { get; init; }

    public ValuesClient Values { get; init; }
}
