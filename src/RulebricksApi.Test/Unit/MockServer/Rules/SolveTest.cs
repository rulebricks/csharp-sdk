using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Rules;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SolveTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "John Doe",
              "age": 30,
              "email": "jdoe@acme.co"
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
                    { "name", "John Doe" },
                    { "age", 30 },
                    { "email", "jdoe@acme.co" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
