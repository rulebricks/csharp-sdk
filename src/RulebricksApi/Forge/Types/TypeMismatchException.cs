namespace RulebricksApi.Forge.Types
{
    public class TypeMismatchException : System.Exception
    {
        public TypeMismatchException(string message) : base(message)
        {
        }
    }

    public class DynamicValueNotFoundException : System.Exception
    {
        public DynamicValueNotFoundException(string message) : base(message)
        {
        }
    }
}
