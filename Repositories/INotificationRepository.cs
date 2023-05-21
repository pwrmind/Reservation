using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.Repositories
{
    public interface INotificationRepository
    {
         Task<IEnumerable<Notification>> ListAsync();
         Task<Notification> AddAsync(string recipientId, string message);
    }
}