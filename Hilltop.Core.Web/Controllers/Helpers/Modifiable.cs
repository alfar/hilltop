using Hilltop.Core.Web.Controllers.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Hilltop.Core.Web.Controllers.Helpers
{
    public class Modifiable : IModifiable
    {
        public Modifiable(object value)
        {
            var jsonSerializer = new JsonSerializer();
            jsonSerializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
            Value = JObject.FromObject(value, jsonSerializer);
        }

        public JObject Value { get; }

        public virtual void AddValue(string propertyName, object value)
        {            
            Value[propertyName] = JToken.FromObject(value);
        }
    }
}