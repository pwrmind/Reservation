using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Repositories
{
    public class ResourceTypeRepository : BaseRepository, IResourceTypeRepository
    {
        public ResourceTypeRepository(ReservationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ResourceType>> ListAsync()
        {
            return await _context.ResourceTypes.ToListAsync();
        }
    }
}