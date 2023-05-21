using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        
        public async Task<IEnumerable<Request>> ListAsync()
        {
            return await _requestRepository.ListAsync();
        }

        public async Task<Request> FindAsync(string id)
        {
            return await _requestRepository.FindAsync(id);
        }

        public async Task<Request> AddAsync(string holderId, List<string> resourceIds, DateTime from, DateTime to, string reason = "")
        {
            return await _requestRepository.AddAsync(holderId, resourceIds, from, to, reason);
        }
    }
}