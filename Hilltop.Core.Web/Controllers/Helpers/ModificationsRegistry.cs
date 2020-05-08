using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Hilltop.Core.Web.Controllers.Interfaces;

namespace Hilltop.Core.Web.Controllers.Helpers
{
    public class ModificationsRegistry : IModificationsRegistry
    {
        private readonly ConcurrentDictionary<Type, ConcurrentBag<Func<object,IModifier>>> modifiers;

        public ModificationsRegistry()
        {
            modifiers = new ConcurrentDictionary<Type, ConcurrentBag<Func<object, IModifier>>>();
        }

        public void AddModifier<T>(Func<object, IModifier> modifier)
        {
            var modifierSet = modifiers.GetOrAdd(typeof(T), (Type t) => new ConcurrentBag<Func<object, IModifier>>());
            modifierSet.Add(modifier);
        }

        public IReadOnlyCollection<IModifier> GetModifiers(object target)
        {
            return target.GetType().GetInterfaces().SelectMany(i => modifiers[i]).Select(m => m(target)).ToList();
        }
    }
}