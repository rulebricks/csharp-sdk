using System.Net.Http;

namespace RulebricksApi.Core;

public static class HttpMethodExtensions
{
    public static readonly HttpMethod Patch = new("PATCH");
}
