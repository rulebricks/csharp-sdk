using RulebricksApi.Core;

namespace RulebricksApi;

public partial class RulebricksApiClient
{
    private readonly RawClient _client;

    public RulebricksApiClient(string? apiKey = null, ClientOptions? clientOptions = null)
    {
        var defaultHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "x-api-key", apiKey },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "RulebricksApi" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
        clientOptions ??= new ClientOptions();
        foreach (var header in defaultHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
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
