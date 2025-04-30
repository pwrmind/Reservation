using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Reservation.Repositories;
using System.Threading.Tasks;

namespace Reservation.Services
{
    /// <summary>
    /// Service responsible for managing notifications in the system.
    /// Handles the creation and delivery of notifications to users.
    /// </summary>
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        /// <summary>
        /// Initializes a new instance of the NotificationService
        /// </summary>
        /// <param name="notificationRepository">The repository used for data access</param>
        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        
        /// <summary>
        /// Retrieves all notifications from the system
        /// </summary>
        /// <returns>A collection of all notifications</returns>
        public async Task<IEnumerable<Notification>> ListAsync()
        {
            return await _notificationRepository.ListAsync();
        }

        /// <summary>
        /// Creates and sends a new notification
        /// </summary>
        /// <param name="recipientId">ID of the resource that will receive the notification</param>
        /// <param name="message">The content of the notification message</param>
        /// <returns>The newly created notification</returns>
        public async Task<Notification> AddAsync(string recipientId, string message)
        {
            return await _notificationRepository.AddAsync(recipientId, message);
        }
    }
}