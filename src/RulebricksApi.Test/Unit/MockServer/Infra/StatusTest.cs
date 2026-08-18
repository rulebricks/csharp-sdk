using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Infra;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class StatusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "status": "scaling",
              "active_workers": 42,
              "target_workers": 128,
              "expires_in_seconds": 547
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/scale").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Infra.StatusAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "status": "ready",
              "active_workers": 128,
              "target_workers": 128,
              "expires_in_seconds": 412
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/scale").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Infra.StatusAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
