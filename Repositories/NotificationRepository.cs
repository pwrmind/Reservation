using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Repositories
{
    public class NotificationRepository : BaseRepository, INotificationRepository
    {
        public NotificationRepository(ReservationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> ListAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification> AddAsync(string recipientId, string message)
        {
            var notification = new Notification(recipientId, message);
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            return notification;
        }
    }
}