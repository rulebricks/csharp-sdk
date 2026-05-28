using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Users;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class InviteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "email": "newuser@example.com",
              "role": "developer",
              "user_groups": [
                "group1",
                "group2"
              ]
            }
            """;

        const string mockResponse = """
            {
              "message": "Invite successful",
              "user": {
                "email": "newuser@example.com",
                "role": "developer",
                "user_groups": [
                  "group1",
                  "group2"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/users/invite")
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

        var response = await Client.Users.InviteAsync(
            new UserInviteRequest
            {
                Email = "newuser@example.com",
                Role = UserInviteRequestRole.Developer,
                UserGroups = new List<string>() { "group1", "group2" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "email": "existinguser@example.com",
              "role": "custom-role",
              "user_groups": [
                "group1"
              ]
            }
            """;

        const string mockResponse = """
            {
              "message": "Invite successful",
              "user": {
                "email": "newuser@example.com",
                "role": "developer",
                "user_groups": [
                  "group1",
                  "group2"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/users/invite")
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

        var response = await Client.Users.InviteAsync(
            new UserInviteRequest
            {
                Email = "existinguser@example.com",
                Role = UserInviteRequestRole.CustomRole,
                UserGroups = new List<string>() { "group1" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "email": "newuser@example.com",
              "role": "developer",
              "user_groups": [
                "group1",
                "group2"
              ]
            }
            """;

        const string mockResponse = """
            {
              "message": "Invite successful",
              "user": {
                "email": "newuser@example.com",
                "role": "developer",
                "user_groups": [
                  "group1",
                  "group2"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/users/invite")
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

        var response = await Client.Users.InviteAsync(
            new UserInviteRequest
            {
                Email = "newuser@example.com",
                Role = UserInviteRequestRole.Developer,
                UserGroups = new List<string>() { "group1", "group2" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "email": "newuser@example.com",
              "role": "developer",
              "user_groups": [
                "group1",
                "group2"
              ]
            }
            """;

        const string mockResponse = """
            {
              "message": "Invitee permissions updated successfully",
              "user": {
                "email": "existinguser@example.com",
                "role": "editor",
                "user_groups": [
                  "group1",
                  "group3"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/users/invite")
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

        var response = await Client.Users.InviteAsync(
            new UserInviteRequest
            {
                Email = "newuser@example.com",
                Role = UserInviteRequestRole.Developer,
                UserGroups = new List<string>() { "group1", "group2" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
