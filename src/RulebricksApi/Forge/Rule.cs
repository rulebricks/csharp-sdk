using System;
using System.Threading.Tasks;
using RulebricksApi.Forge.Types;

namespace RulebricksApi.Forge
{
    public class Rule
    {
        private RulebricksApiClient _workspace;

        public Rule SetWorkspace(RulebricksApiClient client)
        {
            _workspace = client;
            return this;
        }

        // PLACEHOLDER: Additional Rule implementation will be added in the next step
    }
}
