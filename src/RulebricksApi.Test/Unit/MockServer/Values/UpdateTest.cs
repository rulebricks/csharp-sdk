using NUnit.Framework;
using RulebricksApi;
using RulebricksApi.Test_.Unit.MockServer;
using RulebricksApi.Test_.Utils;

namespace RulebricksApi.Test_.Unit.MockServer.Values;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "values": {
                "Favorite Color": "blue",
                "Age": 30,
                "Is Student": false,
                "Hobbies": [
                  "reading",
                  "cycling"
                ]
              },
              "user_groups": [
                "marketing",
                "developers"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "I5RzbYI64h",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "J6SacZJ75i",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    { "Favorite Color", "blue" },
                    { "Age", 30 },
                    { "Is Student", false },
                    {
                        "Hobbies",
                        new List<object?>() { "reading", "cycling" }
                    },
                },
                UserGroups = new List<string>() { "marketing", "developers" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "values": {
                "user_profile": {
                  "first_name": "Alice",
                  "last_name": "Johnson",
                  "contact_info": {
                    "email_address": "alice@example.com",
                    "phone_number": "555-0123"
                  }
                },
                "account_settings": {
                  "is_premium_user": true,
                  "subscription_tier": "gold",
                  "preferences": [
                    "email_notifications",
                    "sms_alerts"
                  ]
                },
                "account_balance": 1250.75
              },
              "user_groups": [
                "marketing",
                "developers"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "I5RzbYI64h",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "J6SacZJ75i",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    {
                        "user_profile",
                        new Dictionary<object, object?>()
                        {
                            {
                                "contact_info",
                                new Dictionary<object, object?>()
                                {
                                    { "email_address", "alice@example.com" },
                                    { "phone_number", "555-0123" },
                                }
                            },
                            { "first_name", "Alice" },
                            { "last_name", "Johnson" },
                        }
                    },
                    {
                        "account_settings",
                        new Dictionary<object, object?>()
                        {
                            { "is_premium_user", true },
                            {
                                "preferences",
                                new List<object?>() { "email_notifications", "sms_alerts" }
                            },
                            { "subscription_tier", "gold" },
                        }
                    },
                    { "account_balance", 1250.75 },
                },
                UserGroups = new List<string>() { "marketing", "developers" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "values": {
                "Company Name": "Acme Corp",
                "company_details": {
                  "founded_year": 2020,
                  "employee_count": 150,
                  "headquarters": {
                    "city": "San Francisco",
                    "state": "CA",
                    "country": "USA"
                  }
                },
                "Is Public": false,
                "tags": [
                  "tech",
                  "startup",
                  "saas"
                ]
              },
              "user_groups": [
                "marketing"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "I5RzbYI64h",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "J6SacZJ75i",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    { "Company Name", "Acme Corp" },
                    {
                        "company_details",
                        new Dictionary<object, object?>()
                        {
                            { "employee_count", 150 },
                            { "founded_year", 2020 },
                            {
                                "headquarters",
                                new Dictionary<object, object?>()
                                {
                                    { "city", "San Francisco" },
                                    { "country", "USA" },
                                    { "state", "CA" },
                                }
                            },
                        }
                    },
                    { "Is Public", false },
                    {
                        "tags",
                        new List<object?>() { "tech", "startup", "saas" }
                    },
                },
                UserGroups = new List<string>() { "marketing" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "values": {
                "Favorite Color": "blue",
                "Age": 30,
                "Is Student": false,
                "Hobbies": [
                  "reading",
                  "cycling"
                ]
              },
              "user_groups": [
                "marketing",
                "developers"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "I5RzbYI64h",
                "name": "Favorite Color",
                "type": "string",
                "value": "blue",
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "J6SacZJ75i",
                "name": "Age",
                "type": "number",
                "value": 30,
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    { "Favorite Color", "blue" },
                    { "Age", 30 },
                    { "Is Student", false },
                    {
                        "Hobbies",
                        new List<object?>() { "reading", "cycling" }
                    },
                },
                UserGroups = new List<string>() { "marketing", "developers" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "values": {
                "Favorite Color": "blue",
                "Age": 30,
                "Is Student": false,
                "Hobbies": [
                  "reading",
                  "cycling"
                ]
              },
              "user_groups": [
                "marketing",
                "developers"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "id": "A1BcdE23f4",
                "name": "user_profile.first_name",
                "type": "string",
                "value": "Alice",
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "B2CdeF34g5",
                "name": "user_profile.last_name",
                "type": "string",
                "value": "Johnson",
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "C3DefG45h6",
                "name": "user_profile.contact_info.email_address",
                "type": "string",
                "value": "alice@example.com",
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "D4EfgH56i7",
                "name": "user_profile.contact_info.phone_number",
                "type": "string",
                "value": "555-0123",
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "E5FghI67j8",
                "name": "account_settings.is_premium_user",
                "type": "boolean",
                "value": true,
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "F6GhiJ78k9",
                "name": "account_settings.subscription_tier",
                "type": "string",
                "value": "gold",
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "G7HijK89l0",
                "name": "account_settings.preferences",
                "type": "list",
                "value": [
                  "email_notifications",
                  "sms_alerts"
                ],
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              },
              {
                "id": "H8IjkL90m1",
                "name": "account_balance",
                "type": "number",
                "value": 1250.75,
                "usages": [
                  {}
                ],
                "user_groups": [
                  "marketing",
                  "developers"
                ],
                "metadata": {
                  "key": "value"
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/values")
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

        var response = await Client.Values.UpdateAsync(
            new UpdateValuesRequest
            {
                Values = new Dictionary<string, object?>()
                {
                    { "Favorite Color", "blue" },
                    { "Age", 30 },
                    { "Is Student", false },
                    {
                        "Hobbies",
                        new List<object?>() { "reading", "cycling" }
                    },
                },
                UserGroups = new List<string>() { "marketing", "developers" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
