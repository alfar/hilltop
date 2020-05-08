using System;
using System.Collections.Generic;

namespace Hilltop.Core.Web.Controllers.Interfaces
{
    public interface IModificationsRegistry
    {
         void AddModifier<T>(Func<object, IModifier> modifier);
         IReadOnlyCollection<IModifier> GetModifiers(object target);
    }
}