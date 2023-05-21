using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Repositories
{
    public class ResourceGroupRepository : BaseRepository, IResourceGroupRepository
    {
        public ResourceGroupRepository(ReservationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ResourceGroup>> ListAsync()
        {
            return await _context.ResourceGroups.ToListAsync();
        }
    }
}