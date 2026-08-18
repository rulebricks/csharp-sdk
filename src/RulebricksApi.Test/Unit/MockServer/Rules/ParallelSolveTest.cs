using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Rules;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ParallelSolveTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "eligibility": {
                "$rule": "1ef03ms",
                "name": "John Doe",
                "age": 30,
                "email": "jdoe@acme.co"
              },
              "offers": {
                "$flow": "OvmsYwn",
                "customer_id": "12345",
                "last_purchase_days_ago": 30,
                "selected_plan": "premium"
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
                {
                    "eligibility",
                    new ParallelSolveRequestValue
                    {
                        Rule = "1ef03ms",
                        AdditionalProperties = new AdditionalProperties
                        {
                            ["name"] = "John Doe",
                            ["age"] = 30,
                            ["email"] = "jdoe@acme.co",
                        },
                    }
                },
                {
                    "offers",
                    new ParallelSolveRequestValue
                    {
                        Flow = "OvmsYwn",
                        AdditionalProperties = new AdditionalProperties
                        {
                            ["customer_id"] = "12345",
                            ["last_purchase_days_ago"] = 30,
                            ["selected_plan"] = "premium",
                        },
                    }
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "eligibility": {
                "$rule": "1ef03ms",
                "name": "John Doe",
                "age": 30,
                "email": "jdoe@acme.co"
              },
              "offers": {
                "$flow": "OvmsYwn",
                "customer_id": "12345",
                "last_purchase_days_ago": 30,
                "selected_plan": "premium"
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
                "$error": {
                  "message": "Flow not found. Ensure that the flow is published and you are using the correct API key.",
                  "status": 404
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/parallel-solve")
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
                {
                    "eligibility",
                    new ParallelSolveRequestValue
                    {
                        Rule = "1ef03ms",
                        AdditionalProperties = new AdditionalProperties
                        {
                            ["name"] = "John Doe",
                            ["age"] = 30,
                            ["email"] = "jdoe@acme.co",
                        },
                    }
                },
                {
                    "offers",
                    new ParallelSolveRequestValue
                    {
                        Flow = "OvmsYwn",
                        AdditionalProperties = new AdditionalProperties
                        {
                            ["customer_id"] = "12345",
                            ["last_purchase_days_ago"] = 30,
                            ["selected_plan"] = "premium",
                        },
                    }
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
