namespace RulebricksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ContentTooLargeError(ContextOperationError body)
    : RulebricksApiApiException("ContentTooLargeError", 413, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new ContextOperationError Body => body;
}
