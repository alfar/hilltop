using System.Collections.Generic;
using Hilltop.Core.Web.Controllers.Interfaces;

namespace Hilltop.Core.Web.Controllers.Helpers
{
    public class Actionable : Modifiable
    {
        private readonly Dictionary<string, string> actions;

        public Actionable(object value) : base(value)
        {
            actions = new Dictionary<string, string>();
        }

        public IReadOnlyDictionary<string, string> Actions => actions;

        public override void AddValue(string propertyName, object value)
        {
            if (propertyName == "actions")
            {
                Action action = value as Action;
                if (action != null)
                {
                    actions.Add(action.Name, action.Uri);
                }

                base.AddValue("actions", actions);
            }
            else
            {
                base.AddValue(propertyName, value);
            }
        }
    }
}