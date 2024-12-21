using System;

namespace RulebricksApi.Forge.Types
{
    public class DynamicValueNotFoundError : Exception
    {
        public DynamicValueNotFoundError(string message) : base(message)
        {
        }

        public DynamicValueNotFoundError(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
