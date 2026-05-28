using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Assets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ExportRbmTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "root_type": "rule",
              "root_ids": [
                "pricing-rule",
                "eligibility-check"
              ],
              "include_downstream": false
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "manifest": {
                "version": "1.0",
                "name": "Export",
                "exported_at": "2024-01-15T10:30:00.000Z",
                "rules": [],
                "flows": [],
                "contexts": [],
                "values": []
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/admin/export")
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

        var response = await Client.Assets.ExportRbmAsync(
            new ExportManifestRequest
            {
                RootType = ExportManifestRequestRootType.Rule,
                RootIds = new List<string>() { "pricing-rule", "eligibility-check" },
                IncludeDownstream = false,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
