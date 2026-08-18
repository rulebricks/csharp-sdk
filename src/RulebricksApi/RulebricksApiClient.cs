using RulebricksApi.Core;
using RulebricksApi.Tests;

namespace RulebricksApi;

public partial class RulebricksApiClient : IRulebricksApiClient
{
    private readonly RawClient _client;

    public RulebricksApiClient(string? apiKey = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "RulebricksApi" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "x-api-key", apiKey ?? "" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Rules = new RulesClient(_client);
        Infra = new InfraClient(_client);
        Flows = new FlowsClient(_client);
        Decisions = new DecisionsClient(_client);
        Users = new UsersClient(_client);
        Assets = new AssetsClient(_client);
        Values = new ValuesClient(_client);
        Objects = new ObjectsClient(_client);
        Contexts = new ContextsClient(_client);
        Tests = new TestsClient(_client);
    }

    public IRulesClient Rules { get; }

    public IInfraClient Infra { get; }

    public IFlowsClient Flows { get; }

    public IDecisionsClient Decisions { get; }

    public IUsersClient Users { get; }

    public IAssetsClient Assets { get; }

    public IValuesClient Values { get; }

    public IObjectsClient Objects { get; }

    public IContextsClient Contexts { get; }

    public ITestsClient Tests { get; }
}
