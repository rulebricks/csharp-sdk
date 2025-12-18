using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class GetUsageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "plan": "Business",
              "monthly_period_start": "04-28-2024",
              "monthly_period_end": "05-28-2024",
              "monthly_executions_usage": 42,
              "monthly_executions_limit": 1000000,
              "monthly_executions_remaining": 999958
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/admin/usage").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.GetUsageAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UsageStatistics>(mockResponse)).UsingDefaults()
        );
    }
}
