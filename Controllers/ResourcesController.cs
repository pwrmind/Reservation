using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reservation.Services;

namespace Reservation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        
        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;   
        }

        [HttpGet()]
        public async Task<IEnumerable<Resource>> GetAllAsync([FromQuery] string typeId){
            if(string.IsNullOrEmpty(typeId)) {
                return await _resourceService.ListAsync();
             } else {
                return await _resourceService.GetResourcesByTypeIdAsync(typeId);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource>> GetResource(string id)
        {
            var request =  await _resourceService.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
        
    }
}
