using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Users;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "email": "newuser@example.com",
              "password": "securePassword123"
            }
            """;

        const string mockResponse = """
            {
              "message": "User newuser@example.com created successfully",
              "user": {
                "id": "c3d4e5f6-a7b8-9012-cdef-123456789012",
                "email": "newuser@example.com",
                "name": "New User",
                "role": "developer",
                "user_groups": [
                  "engineering",
                  "qa"
                ],
                "api_key": "c3d4e5f6-a7b8-9012-cdef-123456789012"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/users/create")
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

        var response = await Client.Users.CreateAsync(
            new CreateUserRequest { Email = "newuser@example.com", Password = "securePassword123" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "email": "newuser@example.com",
              "password": "securePassword123",
              "name": "New User",
              "role": "developer",
              "user_groups": [
                "engineering",
                "qa"
              ]
            }
            """;

        const string mockResponse = """
            {
              "message": "User newuser@example.com created successfully",
              "user": {
                "id": "c3d4e5f6-a7b8-9012-cdef-123456789012",
                "email": "newuser@example.com",
                "name": "New User",
                "role": "developer",
                "user_groups": [
                  "engineering",
                  "qa"
                ],
                "api_key": "c3d4e5f6-a7b8-9012-cdef-123456789012"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/users/create")
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

        var response = await Client.Users.CreateAsync(
            new CreateUserRequest
            {
                Email = "newuser@example.com",
                Password = "securePassword123",
                Name = "New User",
                Role = "developer",
                UserGroups = new List<string>() { "engineering", "qa" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
