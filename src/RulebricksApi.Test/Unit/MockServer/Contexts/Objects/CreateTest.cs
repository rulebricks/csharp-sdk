using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Contexts;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts.Objects;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "Customer",
              "description": "Represents a customer in the system",
              "schema": {
                "base": [
                  {
                    "key": "email",
                    "name": "Email",
                    "type": "string",
                    "required": true
                  },
                  {
                    "key": "age",
                    "name": "Age",
                    "type": "number"
                  }
                ],
                "derived": []
              },
              "identity_fact": "email"
            }
            """;

        const string mockResponse = """
            {
              "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
              "slug": "customer",
              "name": "Customer",
              "created_at": "2024-01-15T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/contexts")
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

        var response = await Client.Contexts.Objects.CreateAsync(
            new CreateContextRequest
            {
                Name = "Customer",
                Description = "Represents a customer in the system",
                Schema = new ContextSchema
                {
                    Base = new List<ContextSchemaField>()
                    {
                        new ContextSchemaField
                        {
                            Key = "email",
                            Name = "Email",
                            Type = ContextSchemaFieldType.String,
                            Required = true,
                        },
                        new ContextSchemaField
                        {
                            Key = "age",
                            Name = "Age",
                            Type = ContextSchemaFieldType.Number,
                        },
                    },
                    Derived = new List<ContextSchemaField>() { },
                },
                IdentityFact = "email",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
