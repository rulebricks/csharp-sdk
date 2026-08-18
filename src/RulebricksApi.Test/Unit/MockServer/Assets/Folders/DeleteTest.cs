using NUnit.Framework;
using RulebricksApi.Assets;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Folders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeleteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "id": "abc123"
            }
            """;

        const string mockResponse = """
            {
              "id": "abc123",
              "name": "Marketing Rules",
              "description": "Rules for marketing automation workflows",
              "type": "rule",
              "created_at": "2024-04-20T10:00:00.000Z",
              "updated_at": "2024-04-23T23:55:38.000Z",
              "user_groups": [
                "user_groups"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/folders")
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

        var response = await Client.Assets.Folders.DeleteAsync(
            new DeleteFolderRequest { Id = "abc123" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
