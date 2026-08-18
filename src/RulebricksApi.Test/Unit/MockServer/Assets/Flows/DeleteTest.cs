using NUnit.Framework;
using RulebricksApi.Assets;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Flows;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "id": "3855f8da-2654-4df9-8903-8f797cbfe8ec"
            }
            """;

        const string mockResponse = """
            {
              "message": "Flow deleted successfully."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/flows/delete")
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

        var response = await Client.Assets.Flows.DeleteAsync(
            new DeleteFlowRequest { Id = "3855f8da-2654-4df9-8903-8f797cbfe8ec" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
