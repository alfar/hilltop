using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hilltop.Core.Web.Controllers;
using Hilltop.Core.Web.Controllers.Interfaces;

using Hilltop.Web.Experiments.Domain;
using Hilltop.Web.Experiments.Controllers.DataTransfer;

namespace Hilltop.Web.Experiments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : HilltopControllerBase
    {
        private readonly IResourceRepository repository;
        private readonly ILogger<ResourceController> logger;

        public ResourceController(IResourceRepository repository, ILogger<ResourceController> logger, IModificationsRegistry modifications) : base(modifications)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet, Route("[controller]/{guid}")]
        public IActionResult GetResource(Guid guid)
        {
            var result = repository.GetResource(guid);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateResource(CreateResourceRequest createRequest)
        {
            repository.CreateResource(createRequest.Guid, createRequest.Name);
            return NoContent();
        }
    }
}
