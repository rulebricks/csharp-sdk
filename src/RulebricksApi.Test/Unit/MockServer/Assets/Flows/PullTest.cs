using NUnit.Framework;
using RulebricksApi.Assets;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Flows;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PullTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "name": "name",
              "description": "description",
              "nodes": [
                {
                  "ref": "code",
                  "type": "code",
                  "rule": "rule",
                  "version": {
                    "key": "value"
                  },
                  "name": "Score Tier Script",
                  "flow": "flow",
                  "outputs": [
                    {
                      "key": "tier",
                      "type": "string"
                    }
                  ],
                  "useCache": true,
                  "cacheExpiration": 1.1,
                  "cacheKey": "cacheKey",
                  "mode": "fields",
                  "aggregations": {
                    "key": {}
                  },
                  "key": "key",
                  "immediateExit": true,
                  "keyMappings": {
                    "key": "value"
                  },
                  "customExitData": "customExitData",
                  "code": "outputs.tier = inputs.score > 700 ? 'A' : 'B'",
                  "prompt": "prompt",
                  "url": "url",
                  "method": "method",
                  "headers": {
                    "key": "value"
                  },
                  "body": {
                    "key": "value"
                  },
                  "jsonPaths": {
                    "key": "value"
                  },
                  "extractPaths": true,
                  "connectionString": "connectionString",
                  "query": "query",
                  "wsdlUrl": "wsdlUrl",
                  "model": "model",
                  "labels": [
                    {
                      "name": "name"
                    }
                  ],
                  "keyType": "keyType",
                  "valueType": "valueType",
                  "defaultValue": {
                    "key": "value"
                  },
                  "provider": "provider",
                  "credentials": {
                    "key": "value"
                  },
                  "secrets": [
                    {
                      "name": "name"
                    }
                  ],
                  "operation": "read",
                  "entitySlug": "entitySlug",
                  "identityFieldKey": "identityFieldKey",
                  "selectedUpdateFields": {
                    "key": true
                  },
                  "updateValues": {
                    "key": "value"
                  },
                  "includeRelations": {
                    "key": true
                  },
                  "channels": {
                    "key": "value"
                  },
                  "titleTemplate": "titleTemplate",
                  "messageTemplate": "messageTemplate",
                  "data": {
                    "key": "value"
                  }
                }
              ],
              "connections": [
                {
                  "from": "from",
                  "to": "to",
                  "output": "output",
                  "input": "input",
                  "control": true
                }
              ],
              "_publish": true,
              "id": "id",
              "stable_id": "stable_id",
              "slug": "slug"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/admin/flows/export").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Assets.Flows.PullAsync(new PullFlowsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
