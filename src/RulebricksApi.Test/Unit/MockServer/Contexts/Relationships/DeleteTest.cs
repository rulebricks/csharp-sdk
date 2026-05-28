using NUnit.Framework;
using RulebricksApi.Contexts;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts.Relationships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "message": "Relationship deleted successfully."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/admin/contexts/a1b2c3d4-e5f6-7890-abcd-ef1234567890/relationships/c3d4e5f6-a7b8-9012-cdef-123456789012"
                    )
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Contexts.Relationships.DeleteAsync(
            new DeleteRelationshipsRequest
            {
                Id = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                Relationship = "c3d4e5f6-a7b8-9012-cdef-123456789012",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
