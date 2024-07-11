using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace RulebricksApi.Core
{
    #nullable enable

    /// <summary>
    /// Utility class for making raw HTTP requests to the API.
    /// </summary>
    public class RawClient
    {
        /// <summary>
        /// The http client used to make requests.
        /// </summary>
        private readonly ClientOptions _clientOptions;

        /// <summary>
        /// Global headers to be sent with every request.
        /// </summary>
        private readonly Dictionary<string, string> _headers;

        public RawClient(Dictionary<string, string> headers, ClientOptions clientOptions)
        {
            _clientOptions = clientOptions;
            _headers = headers;
        }

        public async Task<ApiResponse> MakeRequestAsync(BaseApiRequest request)
        {
            var url = BuildUrl(request.Path, request.Query);
            var httpRequest = new HttpRequestMessage(request.Method, url);
            if (request.ContentType != null)
            {
                request.Headers.Add("Content-Type", request.ContentType);
            }
            // Add global headers to the request
            foreach (var header in _headers)
            {
                httpRequest.Headers.Add(header.Key, header.Value);
            }
            // Add request headers to the request
            foreach (var header in request.Headers)
            {
                httpRequest.Headers.Add(header.Key, header.Value);
            }
            // Add the request body to the request
            if (request is JsonApiRequest jsonRequest)
            {
                if (jsonRequest.Body != null)
                {
                    var serializerOptions = new JsonSerializerOptions { WriteIndented = true, };
                    httpRequest.Content = new StringContent(
                        JsonSerializer.Serialize(jsonRequest.Body, serializerOptions),
                        Encoding.UTF8,
                        "application/json"
                    );
                }
            }
            else if (request is StreamApiRequest { Body: not null } streamRequest)
            {
                httpRequest.Content = new StreamContent(streamRequest.Body);
            }
            // Send the request
            var response = await _clientOptions.HttpClient.SendAsync(httpRequest);
            return new ApiResponse((int)response.StatusCode, response);
        }

        public record BaseApiRequest
        {
            public HttpMethod Method { get; init; }

            public string Path { get; init; }

            public string? ContentType { get; init; }

            public Dictionary<string, object> Query { get; init; } = new();

            public Dictionary<string, string> Headers { get; init; } = new();

            public object? RequestOptions { get; init; }

            public BaseApiRequest(HttpMethod method, string path)
            {
                Method = method;
                Path = path;
            }
        }

        /// <summary>
        /// The request object to be sent for streaming uploads.
        /// </summary>
        public record StreamApiRequest : BaseApiRequest
        {
            public Stream? Body { get; init; }

            public StreamApiRequest(HttpMethod method, string path) : base(method, path) { }
        }

        /// <summary>
        /// The request object to be sent for JSON APIs.
        /// </summary>
        public record JsonApiRequest : BaseApiRequest
        {
            public object? Body { get; init; }

            public JsonApiRequest(HttpMethod method, string path) : base(method, path) { }
        }

        /// <summary>
        /// The response object returned from the API.
        /// </summary>
        public record ApiResponse
        {
            public int StatusCode { get; init; }

            public HttpResponseMessage Raw { get; init; }

            public ApiResponse(int statusCode, HttpResponseMessage raw)
            {
                StatusCode = statusCode;
                Raw = raw;
            }
        }

        private string BuildUrl(string path, Dictionary<string, object> query)
        {
            var trimmedBaseUrl = _clientOptions.BaseUrl.TrimEnd('/');
            var trimmedBasePath = path.TrimStart('/');
            var url = $"{trimmedBaseUrl}/{trimmedBasePath}";
            if (query.Count <= 0)
                return url;
            url += "?";
            url = query.Aggregate(
                url,
                (current, queryItem) => current + $"{queryItem.Key}={queryItem.Value}&"
            );
            url = url.Substring(0, url.Length - 1);
            return url;
        }
    }
}
