using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.Repositories
{
    public interface IResourceRepository
    {
         Task<IEnumerable<Resource>> ListAsync();
         Task<Resource> FindAsync(string id);
         Task<IEnumerable<Resource>> GetResourcesByTypeIdAsync(string typeId);
    }
}