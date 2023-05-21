using System.Collections.Generic;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            this._resourceRepository = resourceRepository;
        }

        public async Task<IEnumerable<Resource>> ListAsync()
        {
            return await _resourceRepository.ListAsync();
        }

        public async Task<Resource> FindAsync(string id)
        {
            return await _resourceRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Resource>> GetResourcesByTypeIdAsync(string typeId)
        {
            return await _resourceRepository.GetResourcesByTypeIdAsync(typeId);
        }
    }
}
