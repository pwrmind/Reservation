using System.Collections.Generic;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    /// <summary>
    /// Service responsible for managing resource groups in the system.
    /// Handles operations related to grouping and organizing resources.
    /// </summary>
    public class ResourceGroupService : IResourceGroupService
    {
        private readonly IResourceGroupRepository _resourceGroupRepository;

        /// <summary>
        /// Initializes a new instance of the ResourceGroupService
        /// </summary>
        /// <param name="resourceGroupRepository">The repository used for data access</param>
        public ResourceGroupService(IResourceGroupRepository resourceGroupRepository)
        {
            this._resourceGroupRepository = resourceGroupRepository;
        }

        /// <summary>
        /// Retrieves all resource groups from the system
        /// </summary>
        /// <returns>A collection of all resource groups</returns>
        public async Task<IEnumerable<ResourceGroup>> ListAsync()
        {
            return await _resourceGroupRepository.ListAsync();
        }
    }
}
