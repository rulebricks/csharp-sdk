![Banner](banner.png)

<p>
    <a href="https://www.nuget.org/packages/RulebricksApi" alt="NuGet">
        <img src="https://img.shields.io/nuget/v/RulebricksApi" /></a>
    <a href="https://github.com/rulebricks/csharp-sdk" alt="License">
        <img src="https://img.shields.io/github/license/rulebricks/csharp-sdk" /></a>
</p>

## Installation

To install the Rulebricks C# SDK, add the following package reference to your project file:

```xml
<PackageReference Include="RulebricksApi" Version="1.5.0" />
```

## Usage

### Initialization

To use the SDK, you need to initialize the `RulebricksApiClient` with your API key:

```csharp
using RulebricksApi;

var apiKey = "your_api_key";
var client = new RulebricksApiClient(apiKey);
```

### Solving a Rule

Here's a simple example of how to solve a rule:

```csharp
var requestData = new Dictionary<string, object>
{
    { "exampleKey", "exampleValue" } // Replace with actual rule data keys and values
};

var result = client.Rules.Solve("example-rule-slug", requestData);
Console.WriteLine($"Result: {result}");
```

### Solving a Flow

Here's a simple example of how to solve a flow:

```csharp
var requestData = new Dictionary<string, object>
{
    { "exampleKey", "exampleValue" } // Replace with actual flow data keys and values
};

var result = client.Flows.Solve("example-flow-slug", requestData);
Console.WriteLine($"Result: {result}");
```

## Forge Module

The Forge module provides a fluent interface for creating and managing rules in your Rulebricks workspace. It offers a type-safe way to define rules, fields, conditions, and dynamic values.

### Rule Creation

```csharp
using RulebricksApi.Forge;

// Create a new rule
var rule = new Rule()
    .SetName("Health Insurance Account Selector")
    .SetDescription("Assists individuals in selecting the most suitable health insurance account option.")
    .SetWorkspace(client);

// Add fields to capture request data
rule
    .AddNumberField("age", "Age of individual", 0)
    .AddBooleanField("hasChronicCondition", "Has any chronic conditions", false)
    .AddNumberField("annualIncome", "Annual income in USD", 0)
    .AddStringField("preferredHospital", "Preferred hospital name")
    .AddListField("currentMedications", "List of current medications");

// Add response fields
rule
    .AddStringResponse("recommendedPlan", "Recommended insurance plan")
    .AddNumberResponse("monthlyPremium", "Monthly premium amount")
    .AddBooleanResponse("hsaEligible", "Eligible for Health Savings Account");

// Create conditions using When() and Any()
rule
    .When(new Dictionary<string, object[]>
    {
        { "age", new object[] { "greater_than", 65 } },
        { "hasChronicCondition", new object[] { "equals", true } }
    })
    .Then(new Dictionary<string, object>
    {
        { "recommendedPlan", "Medicare Advantage Plus" },
        { "monthlyPremium", 175.50 },
        { "hsaEligible", false }
    });

rule
    .Any(new Dictionary<string, object[]>
    {
        { "annualIncome", new object[] { "less_than", 30000 } },
        { "hasChronicCondition", new object[] { "equals", true } }
    })
    .Then(new Dictionary<string, object>
    {
        { "recommendedPlan", "Essential Care Plus" },
        { "monthlyPremium", 125.00 },
        { "hsaEligible", true }
    });

// Save the rule to your workspace
await rule.Update();
```

### Dynamic Values

The Forge module also supports dynamic values that can be managed across your workspace:

```csharp
using RulebricksApi.Forge;

// Configure dynamic values with your workspace
DynamicValues.Configure(client);

// Set dynamic values
await DynamicValues.Set(new Dictionary<string, object>
{
    { "maxDeductible", 5000 },
    { "minPremium", 50 },
    { "availablePlans", new[] { "Basic", "Standard", "Premium" } }
});

// Get a dynamic value reference
var maxDeductible = await DynamicValues.Get("maxDeductible");

// Use dynamic values in rules
rule
    .When(new Dictionary<string, object[]>
    {
        { "annualIncome", new object[] { "greater_than", 50000 } }
    })
    .Then(new Dictionary<string, object>
    {
        { "monthlyPremium", maxDeductible }
    });
```

### Type Safety

The Forge module is built with strong typing and provides compile-time type checking:

```csharp
// Field types are enforced at compile time
rule.AddNumberField("age", "Age of individual", "invalid"); // Compiler error
rule.AddBooleanField("isActive", "Is account active", 0); // Compiler error

// Operator types are validated
rule.When(new Dictionary<string, object[]>
{
    { "age", new object[] { "contains", "value" } }, // Runtime error: 'contains' not valid for number fields
    { "isActive", new object[] { "greater_than", true } } // Runtime error: 'greater_than' not valid for boolean fields
});
```

## Contributing

We welcome contributions to the Rulebricks C# SDK. Please follow these steps to contribute:

1. Fork the repository on GitHub.
2. Create a new branch with a descriptive name.
3. Make your changes and commit them with clear and concise messages.
4. Push your changes to your forked repository.
5. Open a pull request on the main repository.

For major changes, please open an issue first to discuss what you would like to change.

## Troubleshooting

If you encounter any issues while using the SDK, please check the following:

- Ensure that you have the correct API key and that it has the necessary permissions.
- Verify that you are using the correct version of the SDK and .NET framework.
- Check the API reference documentation for any changes or updates to the API endpoints.

If the issue persists, please open an issue on GitHub with detailed information about the problem.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
