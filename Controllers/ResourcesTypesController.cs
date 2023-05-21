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
    public class ResourceTypesController : ControllerBase
    {
        private readonly IResourceTypeService _resourceTypeService;
        
        public ResourceTypesController(IResourceTypeService resourceTypeService)
        {
            _resourceTypeService = resourceTypeService;   
        }

        [HttpGet]
        public async Task<IEnumerable<ResourceType>> GetAllAsync()
        {
            return await _resourceTypeService.ListAsync();;
        }
    }
}
