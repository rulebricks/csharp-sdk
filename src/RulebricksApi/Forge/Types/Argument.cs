using System;
using System.Collections.Generic;

namespace RulebricksApi.Forge.Types
{
    public class Argument<T>
    {
        public T Value { get; }
        public FieldType ExpectedType { get; }

        public Argument(T value, FieldType expectedType)
        {
            Value = value;
            ExpectedType = expectedType;
            ValidateType();
        }

        private void ValidateType()
        {
            var valueType = Value switch
            {
                string => FieldType.String,
                int or double or float or decimal => FieldType.Number,
                bool => FieldType.Boolean,
                DateTime => FieldType.Date,
                IEnumerable<object> => FieldType.List,
                IDictionary<string, object> => FieldType.Object,
                Func<object, object> => FieldType.Function,
                _ => FieldType.Generic
            };

            if (valueType != ExpectedType && ExpectedType != FieldType.Generic)
            {
                throw new TypeMismatchException($"Expected {ExpectedType} but got {valueType}");
            }
        }

        public Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object>
            {
                { "value", Value },
                { "type", ExpectedType.ToString().ToLower() }
            };
        }
    }
}
