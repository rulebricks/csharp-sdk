using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Assets;
using RulebricksApi.Core;
using RulebricksApi.Test_.Unit.MockServer;

namespace RulebricksApi.Test_.Unit.MockServer.Assets;

[TestFixture]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "id": "2855f8da-2654-4df9-8903-8f797cbfe8eb"
            }
            """;

        const string mockResponse = """
            {
              "message": "Rule deleted successfully."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/rules/delete")
                    .WithHeader("Content-Type", "application/json")
                    .UsingDelete()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.Rules.DeleteAsync(
            new DeleteRuleRequest { Id = "2855f8da-2654-4df9-8903-8f797cbfe8eb" }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<SuccessMessage>(mockResponse)).UsingDefaults()
        );
    }
}
