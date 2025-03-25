namespace RulebricksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
public class ForbiddenError(Error body) : RulebricksApiApiException("ForbiddenError", 403, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new Error Body => body;
}
