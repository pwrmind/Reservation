using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.Repositories
{
    public interface IRequestRepository
    {
         Task<IEnumerable<Request>> ListAsync();
         Task<Request> FindAsync(string id);
         Task<Request> AddAsync(string holderId, List<string> resourceIds, DateTime from, DateTime to, string reason);
    }
}