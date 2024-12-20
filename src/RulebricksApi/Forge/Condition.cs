using System.Collections.Generic;

namespace RulebricksApi.Forge
{
    public class Condition
    {
        private readonly Rule _rule;
        private readonly Dictionary<string, (string, object[])> _conditions;
        private readonly Dictionary<string, object> _options;

        public Condition(Rule rule, Dictionary<string, (string, object[])> conditions, Dictionary<string, object> options = null)
        {
            _rule = rule;
            _conditions = conditions;
            _options = options ?? new Dictionary<string, object>();
        }

        public Rule Then(Dictionary<string, object> response)
        {
            var condition = new Dictionary<string, object>
            {
                { "conditions", _conditions },
                { "response", response }
            };

            foreach (var option in _options)
            {
                condition[option.Key] = option.Value;
            }

            _rule._conditions.Add(condition);
            return _rule;
        }
    }
}
