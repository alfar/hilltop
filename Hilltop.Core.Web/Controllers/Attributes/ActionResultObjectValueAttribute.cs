using System;

namespace Hilltop.Core.Web.Controllers.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    internal sealed class ActionResultObjectValueAttribute : Attribute
    {
        public ActionResultObjectValueAttribute()
        {
        }
    }
}