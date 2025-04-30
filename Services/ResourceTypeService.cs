using System.Collections.Generic;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    /// <summary>
    /// Service responsible for managing resource types in the system.
    /// Handles operations related to resource type definitions and categorization.
    /// </summary>
    public class ResourceTypeService : IResourceTypeService
    {
        private readonly IResourceTypeRepository _resourceTypeRepository;

        /// <summary>
        /// Initializes a new instance of the ResourceTypeService
        /// </summary>
        /// <param name="resourceTypeRepository">The repository used for data access</param>
        public ResourceTypeService(IResourceTypeRepository resourceTypeRepository)
        {
            this._resourceTypeRepository = resourceTypeRepository;
        }

        /// <summary>
        /// Retrieves all resource types from the system
        /// </summary>
        /// <returns>A collection of all resource types</returns>
        public async Task<IEnumerable<ResourceType>> ListAsync()
        {
            return await _resourceTypeRepository.ListAsync();
        }
    }
}
