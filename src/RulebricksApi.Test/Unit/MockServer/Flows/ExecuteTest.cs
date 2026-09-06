using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Flows;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ExecuteTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
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
                    .WithPath("/flows/slug/version")
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

        var response = await Client.Flows.ExecuteAsync(
            new ExecuteFlowsRequest
            {
                Slug = "slug",
                Version = "version",
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

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "0": {
                "name": "John Doe",
                "age": 30
              },
              "1": {
                "name": "Jane Doe",
                "age": 28
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
                    .WithPath("/flows/slug/version")
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

        var response = await Client.Flows.ExecuteAsync(
            new ExecuteFlowsRequest
            {
                Slug = "slug",
                Version = "version",
                Body = new Dictionary<string, object?>()
                {
                    {
                        "0",
                        new Dictionary<object, object?>() { { "age", 30 }, { "name", "John Doe" } }
                    },
                    {
                        "1",
                        new Dictionary<object, object?>() { { "age", 28 }, { "name", "Jane Doe" } }
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
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
                    .WithPath("/flows/slug/version")
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

        var response = await Client.Flows.ExecuteAsync(
            new ExecuteFlowsRequest
            {
                Slug = "slug",
                Version = "version",
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

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
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
              "error": "Flow execution failed."
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/flows/slug/version")
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

        var response = await Client.Flows.ExecuteAsync(
            new ExecuteFlowsRequest
            {
                Slug = "slug",
                Version = "version",
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

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "name": "John Doe",
              "age": 30,
              "email": "jdoe@acme.co"
            }
            """;

        const string mockResponse = """
            [
              {
                "eligible": true
              },
              {
                "error": "Flow execution failed."
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/flows/slug/version")
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

        var response = await Client.Flows.ExecuteAsync(
            new ExecuteFlowsRequest
            {
                Slug = "slug",
                Version = "version",
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
