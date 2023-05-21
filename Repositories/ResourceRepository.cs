using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Reservation.Repositories
{
    public class ResourceRepository : BaseRepository, IResourceRepository
    {
        public ResourceRepository(ReservationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Resource>> ListAsync()
        {
            return await _context.Resources
            .Include(r=>r.Type)
            .Include(r=>r.Group)
            .Include(r=>r.Source)
            .ToListAsync();
        }

        public async Task<Resource> FindAsync(string id)
        {
            return await _context.Resources
            .FindAsync(id);
        }

        public async Task<IEnumerable<Resource>> GetResourcesByTypeIdAsync(string typeId)
        {
            return await _context.Resources
            .Include(r=>r.Type)
            .Include(r=>r.Group)
            .Include(r=>r.Source)
            .Where(r=> r.TypeId == typeId)
            .ToListAsync();
        }
    }
}