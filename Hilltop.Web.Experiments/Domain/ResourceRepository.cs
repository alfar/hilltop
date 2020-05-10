using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Hilltop.Web.Experiments.Domain
{
    public class ResourceRepository: IResourceRepository
    {
        private readonly ConcurrentDictionary<Guid, Resource> resources;

        public ResourceRepository()
        {
            resources = new ConcurrentDictionary<Guid, Resource>();
        }

        public void CreateResource(Guid guid, string name)
        {
            var resource = new Resource(guid, name);
            if (!resources.TryAdd(guid, resource))
            {
                throw new ApplicationException("Cannot add resource to store");
            }
        }

        public Resource GetResource(Guid guid)
        {
            return resources.GetValueOrDefault(guid);
        }
    }
}