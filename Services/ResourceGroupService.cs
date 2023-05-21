using System.Collections.Generic;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public class ResourceGroupService : IResourceGroupService
    {
        private readonly IResourceGroupRepository _resourceGroupRepository;

        public ResourceGroupService(IResourceGroupRepository resourceGroupRepository)
        {
            this._resourceGroupRepository = resourceGroupRepository;
        }

        public async Task<IEnumerable<ResourceGroup>> ListAsync()
        {
            return await _resourceGroupRepository.ListAsync();
        }
    }
}
