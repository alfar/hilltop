using Hilltop.Core.Web.Controllers.Interfaces;
using Newtonsoft.Json.Linq;

namespace Hilltop.Core.Web.Controllers.Helpers
{
    public class Modifiable : IModifiable
    {
        public Modifiable(object value)
        {
            Value = JObject.FromObject(value);
        }

        public JObject Value { get; }

        public virtual void AddValue(string propertyName, object value)
        {
            Value[propertyName] = JToken.FromObject(value);
        }
    }
}