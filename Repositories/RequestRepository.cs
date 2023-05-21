using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Reservation.Repositories
{
    public class RequestRepository : BaseRepository, IRequestRepository
    {
        public RequestRepository(ReservationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Request>> ListAsync()
        {
            return await _context.Requests
            .Include(r => r.Holder)
            .Include(r => r.Resources)
            .ToListAsync();
        }

        public async Task<Request> FindAsync(string id)
        {
            return await _context.Requests
            .FindAsync(id);
        }

        public async Task<Request> AddAsync(string holderId, List<string> resourceIds, DateTime from, DateTime to, string reason = "")
        {
            var holder = _context.Resources.Find(holderId);
            var requestId = Guid.NewGuid().ToString();

            var requestResources = resourceIds.Select(id => new RequestResource(requestId, id)).ToList();

            var request = new Request(requestId, holder, requestResources, from, to, reason);
            
            _context.Requests.Add(request);
            
            await _context.SaveChangesAsync();

            return request;
        }
    }
}