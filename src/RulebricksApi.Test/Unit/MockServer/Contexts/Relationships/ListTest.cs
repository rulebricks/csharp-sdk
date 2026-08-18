using NUnit.Framework;
using RulebricksApi.Contexts;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts.Relationships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "context": {
                "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                "name": "Customer",
                "slug": "customer"
              },
              "outgoing": [],
              "incoming": []
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/contexts/a1b2c3d4-e5f6-7890-abcd-ef1234567890/relationships")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Contexts.Relationships.ListAsync(
            new ListRelationshipsRequest { Id = "a1b2c3d4-e5f6-7890-abcd-ef1234567890" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
