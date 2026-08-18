using NUnit.Framework;
using RulebricksApi.Contexts;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Contexts.Relationships;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "to_context_id": "b2c3d4e5-f6a7-8901-bcde-f12345678901",
              "relation_type": "has_many",
              "foreign_key_fact": "customer_id",
              "name": "customer_orders"
            }
            """;

        const string mockResponse = """
            {
              "id": "rel-1234-5678-90ab-cdef12345678",
              "relation_type": "has_many",
              "foreign_key_fact": "customer_id",
              "name": "customer_orders",
              "target_context": {
                "id": "b2c3d4e5-f6a7-8901-bcde-f12345678901",
                "name": "Order",
                "slug": "order"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/contexts/a1b2c3d4-e5f6-7890-abcd-ef1234567890/relationships")
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

        var response = await Client.Contexts.Relationships.CreateAsync(
            new CreateRelationshipRequest
            {
                Id = "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                ToContextId = "b2c3d4e5-f6a7-8901-bcde-f12345678901",
                RelationType = CreateRelationshipRequestRelationType.HasMany,
                ForeignKeyFact = "customer_id",
                Name = "customer_orders",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
