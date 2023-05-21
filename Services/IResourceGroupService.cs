using System.Collections.Generic;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public interface IResourceGroupService
    {
        Task<IEnumerable<ResourceGroup>> ListAsync();
    }
}
