using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Users;

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
                "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                "email": "admin@example.com",
                "name": "Admin User",
                "api_key": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                "role": "administrator",
                "user_groups": [
                  "user_groups"
                ],
                "joined_at": "2024-01-15T10:30:00.000Z"
              },
              {
                "id": "b2c3d4e5-f6a7-8901-bcde-f12345678901",
                "email": "developer@example.com",
                "name": "Developer User",
                "api_key": "b2c3d4e5-f6a7-8901-bcde-f12345678901",
                "role": "developer",
                "user_groups": [
                  "engineering",
                  "qa"
                ],
                "joined_at": "2024-02-20T14:45:00.000Z"
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
