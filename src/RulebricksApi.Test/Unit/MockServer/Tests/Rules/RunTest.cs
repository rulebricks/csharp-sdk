using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;
using RulebricksApi.Tests;

namespace RulebricksApi.Test_.Unit.MockServer.Tests.Rules;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RunTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "critical_only": false
            }
            """;

        const string mockResponse = """
            {
              "rule": "my-rule-slug",
              "flow": "flow",
              "total": 3,
              "passed": 2,
              "failed": 1,
              "pass_percentage": "66.67",
              "critical_failure": true,
              "failed_tests": [
                "Edge case"
              ],
              "critical_failed_tests": [
                "Edge case"
              ],
              "results": [
                {
                  "id": "Wk0CWqGcwrRnezjUJ5N7O",
                  "name": "Happy path",
                  "critical": false,
                  "success": true,
                  "error": false
                },
                {
                  "id": "Mog-TOCOxUFBVXfuk2xVp",
                  "name": "Edge case",
                  "critical": true,
                  "success": false,
                  "error": true
                }
              ],
              "failures": [
                {
                  "id": "Mog-TOCOxUFBVXfuk2xVp",
                  "name": "Edge case",
                  "critical": true,
                  "expected": {
                    "approved": true
                  },
                  "actual": {
                    "approved": false
                  },
                  "matched_rows": [
                    4
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/rules/slug/tests/run")
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

        var response = await Client.Tests.Rules.RunAsync(
            new RunRulesRequest
            {
                Slug = "slug",
                Body = new RunTestsRequest { CriticalOnly = false },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
