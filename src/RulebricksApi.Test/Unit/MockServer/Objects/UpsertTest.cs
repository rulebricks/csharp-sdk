using NUnit.Framework;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Objects;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpsertTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "Claim",
              "content": "{\n  \"type\": \"object\",\n  \"properties\": {\n    \"countryCode\": { \"type\": \"string\", \"title\": \"Country Code\", \"enum\": [\"US\", \"CA\", \"GB\"] }\n  }\n}",
              "user_groups": [
                "underwriting"
              ]
            }
            """;

        const string mockResponse = """
            {
              "dry_run": true,
              "created": true,
              "object": {
                "id": "id",
                "name": "name",
                "content": "content",
                "schema_type": "schema_type",
                "source_format": "source_format",
                "parsed_fields": [
                  {}
                ],
                "user_groups": [
                  "user_groups"
                ],
                "archived_at": "2024-01-15T09:30:00.000Z",
                "created_at": "2024-01-15T09:30:00.000Z",
                "updated_at": "2024-01-15T09:30:00.000Z"
              },
              "values": {
                "synced": 1,
                "archived": 1,
                "would_sync": 1,
                "would_archive": [
                  {}
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/objects")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Objects.UpsertAsync(
            new Dictionary<object, object?>()
            {
                {
                    "content",
                    "{\n  \"type\": \"object\",\n  \"properties\": {\n    \"countryCode\": { \"type\": \"string\", \"title\": \"Country Code\", \"enum\": [\"US\", \"CA\", \"GB\"] }\n  }\n}"
                },
                { "name", "Claim" },
                {
                    "user_groups",
                    new List<object?>() { "underwriting" }
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
