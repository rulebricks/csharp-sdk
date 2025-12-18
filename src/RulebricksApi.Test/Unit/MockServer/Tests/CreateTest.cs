using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Tests;

namespace RulebricksApi.Test_.Unit.MockServer.Tests;

[TestFixture]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "Test 3",
              "request": {
                "param1": "value1"
              },
              "response": {
                "status": "success"
              },
              "critical": true
            }
            """;

        const string mockResponse = """
            {
              "id": "c1a2b3d4-e5f6-7g8h-9i0j-k1l2m3n4o5p6",
              "name": "Test 3",
              "request": {
                "param1": "value1"
              },
              "response": {
                "status": "success"
              },
              "critical": true,
              "error": false,
              "success": false
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/rules/slug/tests")
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

        var response = await Client.Tests.Rules.CreateAsync(
            new CreateRulesRequest
            {
                Slug = "slug",
                Body = new CreateTestRequest
                {
                    Name = "Test 3",
                    Request = new Dictionary<string, object?>() { { "param1", "value1" } },
                    Response = new Dictionary<string, object?>() { { "status", "success" } },
                    Critical = true,
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RulebricksApi.Test>(mockResponse)).UsingDefaults()
        );
    }
}
