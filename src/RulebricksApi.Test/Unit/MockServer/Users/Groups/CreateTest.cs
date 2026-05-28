using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;
using RulebricksApi.Users;

namespace RulebricksApi.Test_.Unit.MockServer.Users.Groups;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "NewGroup",
              "description": "Description of the new group."
            }
            """;

        const string mockResponse = """
            {
              "id": "a1b2c3d4-e5f6-7890-ab12-cd34ef56gh78",
              "name": "NewGroup",
              "description": "Description of the new group.",
              "created_at": "2024-01-15T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/users/groups")
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

        var response = await Client.Users.Groups.CreateAsync(
            new CreateUserGroupRequest
            {
                Name = "NewGroup",
                Description = "Description of the new group.",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
