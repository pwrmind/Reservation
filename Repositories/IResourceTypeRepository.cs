using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Repositories
{
    public interface IResourceTypeRepository
    {
        Task<IEnumerable<ResourceType>> ListAsync();
    }
}