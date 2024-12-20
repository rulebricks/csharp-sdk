using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RulebricksApi.Forge
{
    public class Condition
    {
        private readonly Rule _rule;
        private readonly Dictionary<string, (string, object[])> _conditions;
        private readonly Dictionary<string, object> _options;

        public Condition(
            [NotNull] Rule rule,
            [NotNull] Dictionary<string, (string, object[])> conditions,
            Dictionary<string, object>? options = null)
        {
            _rule = rule ?? throw new ArgumentNullException(nameof(rule));
            _conditions = conditions ?? throw new ArgumentNullException(nameof(conditions));
            _options = options ?? new Dictionary<string, object>();
        }

        public Rule Then([NotNull] Dictionary<string, object> response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

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
