namespace RulebricksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body) : RulebricksApiApiException("BadRequestError", 400, body);
