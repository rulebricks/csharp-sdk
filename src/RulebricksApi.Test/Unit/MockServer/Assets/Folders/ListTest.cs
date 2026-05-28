using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Folders;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTest : BaseMockServerTest
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
                "created_at": "2024-04-20T10:00:00.000Z",
                "updated_at": "2024-04-23T23:55:38.000Z",
                "user_groups": [
                  "marketing"
                ]
              },
              {
                "id": "def456",
                "name": "Sales Qualification",
                "description": "Rules for qualifying sales leads",
                "created_at": "2024-04-18T14:30:00.000Z",
                "updated_at": "2024-04-22T18:30:00.000Z",
                "user_groups": [
                  "user_groups"
                ]
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
