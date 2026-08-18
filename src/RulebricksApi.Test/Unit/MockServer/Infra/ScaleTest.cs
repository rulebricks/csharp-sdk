using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Infra;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ScaleTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "status": "idle",
              "active_workers": 1,
              "target_workers": 1,
              "expires_in_seconds": 1
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/scale").UsingPost())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Infra.ScaleAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
