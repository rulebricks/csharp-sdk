using NUnit.Framework;
using OneOf;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class BulkSolveTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            [
              {
                "name": "John Doe",
                "age": 30,
                "email": "jdoe@acme.co"
              },
              {
                "name": "Jane Doe",
                "age": 28,
                "email": "jane@example.com"
              }
            ]
            """;

        const string mockResponse = """
            [
              {
                "eligible": true,
                "message": "User is eligible for the promotion."
              },
              {
                "eligible": false,
                "message": "User is not eligible for the promotion."
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/bulk-solve/slug")
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

        var response = await Client.Rules.BulkSolveAsync(
            new BulkSolveRulesRequest
            {
                Slug = "slug",
                Body = new List<Dictionary<string, object?>>()
                {
                    new Dictionary<string, object?>()
                    {
                        { "name", "John Doe" },
                        { "age", 30 },
                        { "email", "jdoe@acme.co" },
                    },
                    new Dictionary<string, object?>()
                    {
                        { "name", "Jane Doe" },
                        { "age", 28 },
                        { "email", "jane@example.com" },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<
                        IEnumerable<OneOf<Dictionary<string, object?>, BulkRuleResponseItemError>>
                    >(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
