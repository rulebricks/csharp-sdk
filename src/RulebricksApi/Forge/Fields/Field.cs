using System;
using System.Collections.Generic;
using RulebricksApi.Forge.Types;

namespace RulebricksApi.Forge.Fields
{
    public abstract class Field
    {
        protected readonly string Name;
        protected readonly string Description;
        protected readonly FieldType Type;
        protected readonly object DefaultValue;

        protected Field(string name, string description, FieldType type, object defaultValue)
        {
            Name = name;
            Description = description;
            Type = type;
            DefaultValue = defaultValue;
        }

        public Dictionary<string, object> ToDict()
        {
            return new Dictionary<string, object>
            {
                { "name", Name },
                { "description", Description },
                { "type", Type.ToString().ToLower() },
                { "default", DefaultValue }
            };
        }

        public abstract Dictionary<string, object> BuildOperator(string operatorName, params object[] args);
    }
}
