namespace RulebricksApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class InternalServerError(object body)
    : RulebricksApiApiException("InternalServerError", 500, body);
