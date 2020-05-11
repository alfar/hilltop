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
using Hilltop.Core.Repository;

namespace Hilltop.Web.Experiments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : HilltopControllerBase
    {
        private readonly IRepository<Resource> repository;
        private readonly ILogger<ResourceController> logger;

        public ResourceController(IRepository<Resource> repository, ILogger<ResourceController> logger, IModificationsRegistry modifications) : base(modifications)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet, Route("[controller]/{guid}")]
        public IActionResult GetResource(Guid guid)
        {
            var result = repository.GetByGuid(guid);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateResource(CreateResourceRequest createRequest)
        {
            var resource = new Resource(createRequest.Guid, createRequest.Name);
            repository.Add(resource);
            return NoContent();
        }

        [HttpPost, Route("[controller]/{guid}/bookings")]
        public IActionResult BookResource(Guid guid, [FromBody] BookResourceRequest bookRequest)
        {
            var resource = repository.GetByGuid(guid);

            if (resource == null)
            {
                return NotFound();
            }

            resource.AddBooking(bookRequest.BookingDate, bookRequest.Booker);

            return NoContent();
        }
    }
}
