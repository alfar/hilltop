using System;

namespace Hilltop.Web.Experiments.Domain
{
    public interface IResourceRepository
    {
         void CreateResource(Guid guid, string name);
         Resource GetResource(Guid guid);
    }
}