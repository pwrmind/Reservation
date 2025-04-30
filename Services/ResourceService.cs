using System.Collections.Generic;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    /// <summary>
    /// Service responsible for managing resources in the system.
    /// Handles business logic for resource operations and coordinates with the repository layer.
    /// </summary>
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        /// <summary>
        /// Initializes a new instance of the ResourceService
        /// </summary>
        /// <param name="resourceRepository">The repository used for data access</param>
        public ResourceService(IResourceRepository resourceRepository)
        {
            this._resourceRepository = resourceRepository;
        }

        /// <summary>
        /// Retrieves all resources from the system
        /// </summary>
        /// <returns>A collection of all resources</returns>
        public async Task<IEnumerable<Resource>> ListAsync()
        {
            return await _resourceRepository.ListAsync();
        }

        /// <summary>
        /// Finds a specific resource by its ID
        /// </summary>
        /// <param name="id">The ID of the resource to find</param>
        /// <returns>The resource if found, null otherwise</returns>
        public async Task<Resource> FindAsync(string id)
        {
            return await _resourceRepository.FindAsync(id);
        }

        /// <summary>
        /// Retrieves all resources of a specific type
        /// </summary>
        /// <param name="typeId">The ID of the resource type</param>
        /// <returns>A collection of resources matching the specified type</returns>
        public async Task<IEnumerable<Resource>> GetResourcesByTypeIdAsync(string typeId)
        {
            return await _resourceRepository.GetResourcesByTypeIdAsync(typeId);
        }
    }
}
