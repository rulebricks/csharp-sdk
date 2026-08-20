using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Objects;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "message": "message",
              "values": {
                "total": 1,
                "deleted": 1,
                "detached": 1,
                "archived": 1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/objects/objectId")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Objects.DeleteAsync(
            new RulebricksApi.DeleteObjectsRequest { ObjectId = "objectId" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
