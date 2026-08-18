using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Values;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SyncTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "collection": "Medical Codes",
              "values": {
                "A123": "A123",
                "B456": "B456",
                "C789": "C789"
              }
            }
            """;

        const string mockResponse = """
            {
              "collection": "collection",
              "sync_id": "sync_id",
              "already_completed": true,
              "dry_run": true,
              "swept": true,
              "created": 1,
              "updated": 1,
              "unchanged": 1,
              "processed": 1,
              "archived": 1,
              "deleted": 1,
              "blocked": [
                {
                  "id": "id",
                  "name": "name",
                  "reason": "reason",
                  "action": "archived"
                }
              ],
              "errors": [
                {
                  "name": "name",
                  "error": "error"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values/sync")
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

        var response = await Client.Values.SyncAsync(
            new SyncValuesRequest
            {
                Collection = "Medical Codes",
                Values = new Dictionary<string, object?>()
                {
                    { "A123", "A123" },
                    { "B456", "B456" },
                    { "C789", "C789" },
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
              "collection": "Medical Codes",
              "values": {
                "Y998": "Y998",
                "Z999": "Z999"
              },
              "sync_id": "fabric-2026-08-13T02:00Z",
              "complete": true
            }
            """;

        const string mockResponse = """
            {
              "collection": "collection",
              "sync_id": "sync_id",
              "already_completed": true,
              "dry_run": true,
              "swept": true,
              "created": 1,
              "updated": 1,
              "unchanged": 1,
              "processed": 1,
              "archived": 1,
              "deleted": 1,
              "blocked": [
                {
                  "id": "id",
                  "name": "name",
                  "reason": "reason",
                  "action": "archived"
                }
              ],
              "errors": [
                {
                  "name": "name",
                  "error": "error"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values/sync")
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

        var response = await Client.Values.SyncAsync(
            new SyncValuesRequest
            {
                Collection = "Medical Codes",
                Values = new Dictionary<string, object?>()
                {
                    { "Y998", "Y998" },
                    { "Z999", "Z999" },
                },
                SyncId = "fabric-2026-08-13T02:00Z",
                Complete = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
