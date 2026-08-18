using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Assets;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets.Flows;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PushTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "flow": {
                "name": "Underwriting Flow",
                "_publish": true,
                "nodes": [
                  {
                    "ref": "input",
                    "type": "origin",
                    "rule": "customer-eligibility"
                  },
                  {
                    "ref": "gate",
                    "type": "continue_if",
                    "condition": {
                      "property": "approved",
                      "operator": "equals",
                      "args": [
                        true
                      ]
                    }
                  },
                  {
                    "ref": "enrich",
                    "type": "code",
                    "code": "outputs.tier = inputs.score > 700 ? 'A' : 'B'",
                    "outputs": [
                      {
                        "key": "tier",
                        "type": "string"
                      }
                    ]
                  },
                  {
                    "ref": "out",
                    "type": "result",
                    "key": "data"
                  }
                ],
                "connections": [
                  {
                    "from": "input",
                    "output": "approved",
                    "to": "gate"
                  },
                  {
                    "from": "input",
                    "output": "score",
                    "to": "enrich",
                    "input": "score"
                  },
                  {
                    "from": "gate",
                    "to": "out",
                    "control": true
                  },
                  {
                    "from": "enrich",
                    "output": "tier",
                    "to": "out"
                  }
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "name": "Underwriting Flow",
              "id": "3855f8da-2654-4df9-8903-8f797cbfe8ec",
              "slug": "x6Q4zhD_Lm"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/flows/import")
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

        var response = await Client.Assets.Flows.PushAsync(
            new ImportFlowRequest
            {
                Flow = new FlowImportPayload
                {
                    Name = "Underwriting Flow",
                    Publish = true,
                    Nodes = new List<RulebricksFlowNode>()
                    {
                        new RulebricksFlowNode
                        {
                            Ref = "input",
                            Type = RulebricksFlowNodeType.Origin,
                            Rule = "customer-eligibility",
                        },
                        new RulebricksFlowNode
                        {
                            Ref = "gate",
                            Type = RulebricksFlowNodeType.ContinueIf,
                            Condition = new RulebricksFlowNodeCondition
                            {
                                Property = "approved",
                                Operator = "equals",
                                Args = new List<object>() { true },
                            },
                        },
                        new RulebricksFlowNode
                        {
                            Ref = "enrich",
                            Type = RulebricksFlowNodeType.Code,
                            Code = "outputs.tier = inputs.score > 700 ? 'A' : 'B'",
                            Outputs = new List<RulebricksFlowNodeOutputsItem>()
                            {
                                new RulebricksFlowNodeOutputsItem
                                {
                                    Key = "tier",
                                    Type = RulebricksFlowNodeOutputsItemType.String,
                                },
                            },
                        },
                        new RulebricksFlowNode
                        {
                            Ref = "out",
                            Type = RulebricksFlowNodeType.Result,
                            Key = "data",
                        },
                    },
                    Connections = new List<RulebricksFlowConnection>()
                    {
                        new RulebricksFlowConnection
                        {
                            From = "input",
                            Output = "approved",
                            To = "gate",
                        },
                        new RulebricksFlowConnection
                        {
                            From = "input",
                            Output = "score",
                            To = "enrich",
                            Input = "score",
                        },
                        new RulebricksFlowConnection
                        {
                            From = "gate",
                            To = "out",
                            Control = true,
                        },
                        new RulebricksFlowConnection
                        {
                            From = "enrich",
                            Output = "tier",
                            To = "out",
                        },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
