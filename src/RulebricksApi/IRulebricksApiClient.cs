using RulebricksApi.Tests;

namespace RulebricksApi;

public partial interface IRulebricksApiClient
{
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
