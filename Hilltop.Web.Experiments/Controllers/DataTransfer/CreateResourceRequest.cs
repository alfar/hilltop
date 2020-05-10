using System;

namespace Hilltop.Web.Experiments.Controllers.DataTransfer
{
    public class CreateResourceRequest
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
    }
}