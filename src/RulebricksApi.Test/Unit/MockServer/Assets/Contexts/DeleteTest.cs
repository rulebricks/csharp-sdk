using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Contexts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "message": "Context deleted"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/contexts/a1b2c3d4-e5f6-7890-abcd-ef1234567890")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.Contexts.DeleteAsync(
            new RulebricksApi.Assets.DeleteContextsRequest
            {
                Id = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
