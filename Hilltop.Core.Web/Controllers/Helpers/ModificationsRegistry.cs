using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Hilltop.Core.Web.Controllers.Interfaces;

namespace Hilltop.Core.Web.Controllers.Helpers
{
    public class ModificationsRegistry : IModificationsRegistry
    {
        private readonly ConcurrentDictionary<Type, ConcurrentBag<Delegate>> modifiers;

        public ModificationsRegistry()
        {
            modifiers = new ConcurrentDictionary<Type, ConcurrentBag<Delegate>>();
        }

        public void AddModifier<T>(Func<T, IModifier> modifier)
        {
            var modifierSet = modifiers.GetOrAdd(typeof(T), (Type t) => new ConcurrentBag<Delegate>());
            modifierSet.Add(modifier);
        }

        private static ConcurrentBag<Delegate> Empty = new ConcurrentBag<Delegate>();

        public IReadOnlyCollection<IModifier> GetModifiers(object target)
        {
            return target.GetType().GetInterfaces().SelectMany(i => modifiers.TryGetValue(i, out var value) ? value : Empty).Select(m => m.DynamicInvoke(target) as IModifier).ToList();
        }
    }
}