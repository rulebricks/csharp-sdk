using NUnit.Framework;
using RulebricksApi.Assets;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Folders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "Marketing Rules",
              "description": "Rules for marketing automation workflows"
            }
            """;

        const string mockResponse = """
            {
              "id": "abc123",
              "name": "Marketing Rules",
              "description": "Rules for marketing automation workflows",
              "type": "rule",
              "created_at": "2024-01-15T09:30:00.000Z",
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
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.Folders.UpsertAsync(
            new UpsertFolderRequest
            {
                Name = "Marketing Rules",
                Description = "Rules for marketing automation workflows",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
