using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts.Objects;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
              "name": "Customer",
              "slug": "customer",
              "description": "Represents a customer in the system",
              "schema": {
                "base": [
                  {
                    "key": "email",
                    "name": "Email",
                    "type": "string"
                  },
                  {
                    "key": "age",
                    "name": "Age",
                    "type": "number"
                  }
                ],
                "derived": []
              },
              "identity_fact": "email",
              "ttl_seconds": 3600,
              "history_limit": 100,
              "on_schema_mismatch": "ignore",
              "auto_execute_decisions": true,
              "bound_rules": [
                {
                  "id": "rule-5678-90ab-cdef-123456789012",
                  "name": "Customer Pricing Rule",
                  "slug": "pricing-rule",
                  "published": true
                }
              ],
              "bound_flows": [],
              "relationships": {
                "outgoing": [],
                "incoming": []
              },
              "created_at": "2024-01-15T10:30:00.000Z",
              "updated_at": "2024-01-15T10:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/contexts/a1b2c3d4-e5f6-7890-abcd-ef1234567890")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Contexts.Objects.GetAsync(
            new RulebricksApi.Contexts.GetObjectsRequest
            {
                Id = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
