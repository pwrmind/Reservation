using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> ListAsync();
        Task<Notification> AddAsync(string recipientId, string message);
    }
}