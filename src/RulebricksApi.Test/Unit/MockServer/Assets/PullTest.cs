using NUnit.Framework;
using RulebricksApi.Assets;
using RulebricksApi.Core;
using RulebricksApi.Test_.Unit.MockServer;

namespace RulebricksApi.Test_.Unit.MockServer.Assets;

[TestFixture]
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<Dictionary<string, object?>>(mockResponse))
                .UsingDefaults()
        );
    }
}
