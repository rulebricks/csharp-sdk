using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Users;

namespace RulebricksApi.Test_.Unit.MockServer.Users;

[TestFixture]
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
              "members": []
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
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UserGroup>(mockResponse)).UsingDefaults()
        );
    }
}
