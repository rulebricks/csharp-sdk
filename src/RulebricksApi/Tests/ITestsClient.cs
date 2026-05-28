namespace RulebricksApi.Tests;

public partial interface ITestsClient
{
    public IRulesClient Rules { get; }
    public IFlowsClient Flows { get; }
}
