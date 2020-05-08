using Microsoft.AspNetCore.Mvc;
using Hilltop.Core.Web.Controllers.Attributes;
using Hilltop.Core.Web.Controllers.Helpers;
using Hilltop.Core.Web.Controllers.Interfaces;

namespace Hilltop.Core.Web.Controllers
{
    public class HilltopControllerBase : ControllerBase
    {
        private readonly IModificationsRegistry modifications;

        public HilltopControllerBase(IModificationsRegistry modifications)
        {
            this.modifications = modifications;
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object value) {
            var actionable = new Actionable(value);

            foreach(IModifier modifier in modifications.GetModifiers(value))
            {
                modifier.Modify(actionable);
            }

            return base.Ok(actionable);
        }
    }
}