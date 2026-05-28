using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
              "monthly_executions_remaining": 999958,
              "unlimited_plan": true,
              "days_remaining_in_period": 1.1,
              "daily_average_usage": 1.1
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
