using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reservation;
using Microsoft.EntityFrameworkCore;
using Reservation.Services;

namespace Reservation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;


        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IEnumerable<Request>> GetRequests()
        {
            return await _requestService.ListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(string id)
        {
            var request = await _requestService.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }
/*
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(Guid id, Request request)
        {
            if (id.ToString() != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool RequestExists(Guid id)
        {
            return _context.Requests.Any(e => e.Id == id.ToString());
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(Guid id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }
*/

        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(string holderId, string resourceIds, DateTime from, DateTime to, string reason = "")
        {
            var request = await _requestService.AddAsync(holderId, resourceIds.Split(",").ToList(), from, to, reason);

            return request;
        }

    }
}
