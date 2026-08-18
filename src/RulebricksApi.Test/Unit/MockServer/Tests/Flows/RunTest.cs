using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;
using RulebricksApi.Tests;

namespace RulebricksApi.Test_.Unit.MockServer.Tests.Flows;

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
              "rule": "rule",
              "flow": "my-flow-slug",
              "total": 2,
              "passed": 2,
              "failed": 0,
              "pass_percentage": "100.00",
              "critical_failure": false,
              "failed_tests": [
                "failed_tests"
              ],
              "critical_failed_tests": [
                "critical_failed_tests"
              ],
              "results": [
                {
                  "id": "Wk0CWqGcwrRnezjUJ5N7O",
                  "name": "Approves valid applicant",
                  "critical": true,
                  "success": true,
                  "error": false
                }
              ],
              "failures": [
                {
                  "id": "id",
                  "name": "name",
                  "critical": true,
                  "expected": {
                    "key": "value"
                  },
                  "actual": {
                    "key": "value"
                  },
                  "matched_rows": [
                    1
                  ],
                  "error_message": "error_message"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/flows/slug/tests/run")
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

        var response = await Client.Tests.Flows.RunAsync(
            new RunFlowsRequest
            {
                Slug = "slug",
                Body = new RunTestsRequest { CriticalOnly = false },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
