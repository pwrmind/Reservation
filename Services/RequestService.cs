using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    /// <summary>
    /// Service responsible for managing reservation requests.
    /// Handles the business logic for creating, retrieving, and managing requests.
    /// </summary>
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        /// <summary>
        /// Initializes a new instance of the RequestService
        /// </summary>
        /// <param name="requestRepository">The repository used for data access</param>
        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }
        
        /// <summary>
        /// Retrieves all reservation requests from the system
        /// </summary>
        /// <returns>A collection of all requests</returns>
        public async Task<IEnumerable<Request>> ListAsync()
        {
            return await _requestRepository.ListAsync();
        }

        /// <summary>
        /// Finds a specific reservation request by its ID
        /// </summary>
        /// <param name="id">The ID of the request to find</param>
        /// <returns>The request if found, null otherwise</returns>
        public async Task<Request> FindAsync(string id)
        {
            return await _requestRepository.FindAsync(id);
        }

        /// <summary>
        /// Creates a new reservation request
        /// </summary>
        /// <param name="holderId">ID of the resource making the request</param>
        /// <param name="resourceIds">List of resource IDs to be reserved</param>
        /// <param name="from">Start date and time of the reservation</param>
        /// <param name="to">End date and time of the reservation</param>
        /// <param name="reason">Optional reason for the reservation</param>
        /// <returns>The newly created request</returns>
        public async Task<Request> AddAsync(string holderId, List<string> resourceIds, DateTime from, DateTime to, string reason = "")
        {
            return await _requestRepository.AddAsync(holderId, resourceIds, from, to, reason);
        }
    }
}