using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class SolveTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "body": {
                "name": "Alice Johnson",
                "age": 28,
                "email": "alice.johnson@example.com"
              }
            }
            """;

        const string mockResponse = """
            {
              "eligible": true,
              "message": "User is eligible for the promotion."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/solve/slug")
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

        var response = await Client.Rules.SolveAsync(
            new SolveRulesRequest
            {
                Slug = "slug",
                Body = new Dictionary<string, object?>()
                {
                    {
                        "body",
                        new Dictionary<object, object?>()
                        {
                            { "age", 28 },
                            { "email", "alice.johnson@example.com" },
                            { "name", "Alice Johnson" },
                        }
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<Dictionary<string, object?>>(mockResponse))
                .UsingDefaults()
        );
    }
}
