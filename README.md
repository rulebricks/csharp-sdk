# Rulebricks C# SDK

## Overview

The Rulebricks C# SDK provides a convenient way to interact with the Rulebricks API. It allows you to manage rules, flows, and values within your application.

## Installation

To install the Rulebricks C# SDK, add the following package reference to your project file:

```xml
<PackageReference Include="RulebricksApi" Version="0.0.43" />
```

## Usage

### Initialization

To use the SDK, you need to initialize the `RulebricksApiClient` with your API key:

```csharp
using RulebricksApi;

var apiKey = "your_api_key";
var client = new RulebricksApiClient(apiKey);
```

### Authenticating

Before you can start using the SDK, you need to configure it with your Rulebricks API key:

```csharp
var apiKey = "YOUR_API_KEY";
var client = new RulebricksApiClient(apiKey);
```

### Solving a Rule

Here's a simple example of how to solve a rule:

```csharp
var requestData = new Dictionary<string, object>
{
    { "dataKey", "dataValue" } // Replace with actual rule data keys and values
};

var result = client.Rules.Solve("rule-slug", requestData);
Console.WriteLine($"Result: {result}");
```

### Solving a Flow

Here's a simple example of how to solve a flow:

```csharp
var requestData = new Dictionary<string, object>
{
    { "dataKey", "dataValue" } // Replace with actual flow data keys and values
};

var result = client.Flows.Solve("flow-slug", requestData);
Console.WriteLine($"Result: {result}");
```

## Contributing

We welcome contributions to the Rulebricks C# SDK. Please open an issue or submit a pull request on GitHub.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
