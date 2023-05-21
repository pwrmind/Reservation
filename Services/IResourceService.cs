using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> ListAsync();
        Task<Resource> FindAsync(string id);
        Task<IEnumerable<Resource>> GetResourcesByTypeIdAsync(string typeId);
    }
}