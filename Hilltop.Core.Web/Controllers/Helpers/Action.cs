namespace Hilltop.Core.Web.Controllers.Helpers
{
    public class Action
    {
        public Action(string name, string uri)
        {
            Name = name;
            Uri = uri;
        }

        public string Name { get; }
        public string Uri { get; }
    }
}