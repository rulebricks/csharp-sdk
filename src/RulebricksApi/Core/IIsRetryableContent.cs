namespace RulebricksApi.Core;

public interface IIsRetryableContent
{
    public bool IsRetryable { get; }
}
