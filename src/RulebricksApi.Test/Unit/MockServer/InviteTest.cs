using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class InviteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "email": "newuser@example.com",
              "role": "developer",
              "accessGroups": [
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
                "accessGroups": [
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
                AccessGroups = new List<string>() { "group1", "group2" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UserInviteResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "email": "existinguser@example.com",
              "role": "custom-role",
              "accessGroups": [
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
                "accessGroups": [
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
                AccessGroups = new List<string>() { "group1" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UserInviteResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "email": "newuser@example.com",
              "role": "developer",
              "accessGroups": [
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
                "accessGroups": [
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
                AccessGroups = new List<string>() { "group1", "group2" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UserInviteResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "email": "newuser@example.com",
              "role": "developer",
              "accessGroups": [
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
                "accessGroups": [
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
                AccessGroups = new List<string>() { "group1", "group2" },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<UserInviteResponse>(mockResponse)).UsingDefaults()
        );
    }
}
