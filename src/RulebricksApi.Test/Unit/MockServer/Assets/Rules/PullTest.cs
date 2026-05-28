using NUnit.Framework;
using RulebricksApi.Assets;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Rules;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PullTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {}
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/rules/export")
                    .WithParam("id", "2855f8da-2654-4df9-8903-8f797cbfe8eb")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.Rules.PullAsync(
            new PullRulesRequest { Id = "2855f8da-2654-4df9-8903-8f797cbfe8eb" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
