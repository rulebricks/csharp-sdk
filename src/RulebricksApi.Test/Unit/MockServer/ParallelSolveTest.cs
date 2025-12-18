using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Core;

namespace RulebricksApi.Test_.Unit.MockServer;

[TestFixture]
public class ParallelSolveTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "body": {
                "eligibility": {
                  "$rule": "1ef03ms",
                  "name": "Alice Johnson",
                  "age": 28,
                  "email": "alice.johnson@example.com"
                },
                "offers": {
                  "$flow": "OvmsYwn",
                  "customer_id": "98765",
                  "last_purchase_days_ago": 15,
                  "selected_plan": "gold"
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "eligibility": {
                "eligible": true,
                "message": "User is eligible for the product."
              },
              "offers": {
                "flat_discount": 13.2,
                "free_shipping": true
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/parallel-solve")
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

        var response = await Client.Rules.ParallelSolveAsync(
            new Dictionary<string, ParallelSolveRequestValue>()
            {
                { "body", new ParallelSolveRequestValue() },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<Dictionary<string, Dictionary<string, object?>>>(
                        mockResponse
                    )
                )
                .UsingDefaults()
        );
    }
}
