using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Assets;
using RulebricksApi.Core;
using RulebricksApi.Test_.Unit.MockServer;

namespace RulebricksApi.Test_.Unit.MockServer.Assets;

[TestFixture]
public class DeleteTest_ : BaseMockServerTest
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
              "updatedAt": "2024-04-23T23:55:38.000Z"
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<Folder>(mockResponse)).UsingDefaults()
        );
    }
}
