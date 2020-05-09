namespace Hilltop.Web.Experiments.Domain
{
    public interface IInvitable
    {
        bool CanInvite { get; }
        bool CanUninvite { get; }
    }
}