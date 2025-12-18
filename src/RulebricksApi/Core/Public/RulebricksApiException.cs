namespace RulebricksApi;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class RulebricksApiException(string message, Exception? innerException = null)
    : Exception(message, innerException);
