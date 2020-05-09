namespace Hilltop.Web.Experiments.Domain
{
    public class Resource : IResource, IInvitable
    {
        public string Name { get; set; }

        public bool CanInvite => true;
        public bool CanUninvite => false;
    }
}