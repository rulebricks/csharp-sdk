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
<PackageReference Include="RulebricksApi" Version="1.8.0" />
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
