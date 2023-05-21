using System.Collections.Generic;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public class ResourceTypeService : IResourceTypeService
    {
        private readonly IResourceTypeRepository _resourceTypeRepository;

        public ResourceTypeService(IResourceTypeRepository resourceTypeRepository)
        {
            this._resourceTypeRepository = resourceTypeRepository;
        }

        public async Task<IEnumerable<ResourceType>> ListAsync()
        {
            return await _resourceTypeRepository.ListAsync();
        }
    }
}
