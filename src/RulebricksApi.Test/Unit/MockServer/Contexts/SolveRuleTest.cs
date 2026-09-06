using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SolveRuleTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "email": "john@example.com",
              "score": 85
            }
            """;

        const string mockResponse = """
            {
              "status": "solved",
              "context": "customer:cust-12345",
              "rule": "rule",
              "result": {
                "key": "value"
              },
              "written_to_context": [
                "written_to_context"
              ],
              "cascaded": [
                {
                  "context": "context",
                  "rule": "rule",
                  "flow": "flow",
                  "execution_id": "execution_id",
                  "status": "solved",
                  "result": {
                    "key": "value"
                  },
                  "auto_executed": true,
                  "written_to_context": [
                    "written_to_context"
                  ],
                  "error": "error",
                  "rate_limited": true,
                  "usage_limited": true,
                  "need": [
                    "need"
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/contexts/slug/instance/solve/ruleSlug")
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

        var response = await Client.Contexts.SolveRuleAsync(
            new SolveRuleContextsRequest
            {
                Slug = "slug",
                Instance = "instance",
                RuleSlug = "ruleSlug",
                Body = new Dictionary<string, object?>()
                {
                    { "email", "john@example.com" },
                    { "score", 85 },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
