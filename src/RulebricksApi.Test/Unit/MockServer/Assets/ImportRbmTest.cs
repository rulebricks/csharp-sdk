using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ImportRbmTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "manifest": {
                "version": "1.0",
                "rules": [
                  {
                    "name": "Pricing Rule",
                    "slug": "pricing-rule"
                  }
                ],
                "flows": [
                  {
                    "name": "Onboarding Flow",
                    "slug": "onboarding-flow"
                  }
                ],
                "entities": [
                  {
                    "name": "Customer",
                    "slug": "customer"
                  }
                ],
                "values": [
                  {
                    "name": "tax_rate",
                    "value": 0.08
                  }
                ]
              },
              "conflict_strategy": "update"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "created": [],
              "updated": [],
              "skipped": [],
              "errors": []
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/import")
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

        var response = await Client.Assets.ImportRbmAsync(
            new ImportManifestRequest
            {
                Manifest = new ImportManifestRequestManifest
                {
                    Version = "1.0",
                    Rules = new List<ManifestLabeledAsset>()
                    {
                        new ManifestLabeledAsset
                        {
                            AdditionalProperties = new AdditionalProperties
                            {
                                ["name"] = "Pricing Rule",
                                ["slug"] = "pricing-rule",
                            },
                        },
                    },
                    Flows = new List<ManifestLabeledAsset>()
                    {
                        new ManifestLabeledAsset
                        {
                            AdditionalProperties = new AdditionalProperties
                            {
                                ["name"] = "Onboarding Flow",
                                ["slug"] = "onboarding-flow",
                            },
                        },
                    },
                    Entities = new List<Dictionary<string, object?>>()
                    {
                        new Dictionary<string, object?>()
                        {
                            { "name", "Customer" },
                            { "slug", "customer" },
                        },
                    },
                    Values = new List<Dictionary<string, object?>>()
                    {
                        new Dictionary<string, object?>()
                        {
                            { "name", "tax_rate" },
                            { "value", 0.08 },
                        },
                    },
                },
                ConflictStrategy = ImportManifestRequestConflictStrategy.Update,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
