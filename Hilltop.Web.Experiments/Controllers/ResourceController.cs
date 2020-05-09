using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hilltop.Core.Web.Controllers;
using Hilltop.Core.Web.Controllers.Interfaces;

using Hilltop.Web.Experiments.Domain;

namespace Hilltop.Web.Experiments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : HilltopControllerBase
    {
        private readonly ILogger<ResourceController> _logger;

        public ResourceController(ILogger<ResourceController> logger, IModificationsRegistry modifications) : base(modifications)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetResource()
        {
            return Ok(new Resource() { Name = "Laptop" });
        }
    }
}
