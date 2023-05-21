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
    public class ResourceGroupsController : ControllerBase
    {
        private readonly IResourceGroupService _resourceGroupService;
        
        public ResourceGroupsController(IResourceGroupService resourceGroupService)
        {
            _resourceGroupService = resourceGroupService;   
        }

        [HttpGet]
        public async Task<IEnumerable<ResourceGroup>> GetAllAsync()
        {
            return await _resourceGroupService.ListAsync();;
        }
    }
}
