using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        
        public async Task<IEnumerable<Notification>> ListAsync()
        {
            return await _notificationRepository.ListAsync();
        }

        public async Task<Notification> AddAsync(string recipientId, string message)
        {
            return await _notificationRepository.AddAsync(recipientId, message);
        }
    }
}