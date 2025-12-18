using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                "email": "admin@example.com",
                "name": "Admin User",
                "apiKey": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                "role": "administrator",
                "accessGroups": [
                  "accessGroups"
                ],
                "joinedAt": "2024-01-15T10:30:00.000Z"
              },
              {
                "id": "b2c3d4e5-f6a7-8901-bcde-f12345678901",
                "email": "developer@example.com",
                "name": "Developer User",
                "apiKey": "b2c3d4e5-f6a7-8901-bcde-f12345678901",
                "role": "developer",
                "accessGroups": [
                  "engineering",
                  "qa"
                ],
                "joinedAt": "2024-02-20T14:45:00.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/admin/users/list").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Users.ListAsync();
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<UserDetail>>(mockResponse)).UsingDefaults()
        );
    }
}
