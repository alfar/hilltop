using System;

namespace Hilltop.Web.Experiments.Domain
{
    public interface IResource
    {
        Guid Guid { get; }
        string Name { get; }
    }
}