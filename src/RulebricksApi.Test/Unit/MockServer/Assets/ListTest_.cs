using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;
using RulebricksApi.Test_.Unit.MockServer;

namespace RulebricksApi.Test_.Unit.MockServer.Assets;

[TestFixture]
public class ListTest_ : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "id": "abc123",
                "name": "Marketing Rules",
                "description": "Rules for marketing automation workflows",
                "updatedAt": "2024-04-23T23:55:38.000Z"
              },
              {
                "id": "def456",
                "name": "Sales Qualification",
                "description": "Rules for qualifying sales leads",
                "updatedAt": "2024-04-22T18:30:00.000Z"
              }
            ]
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/admin/folders").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.Folders.ListAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<Folder>>(mockResponse)).UsingDefaults()
        );
    }
}
