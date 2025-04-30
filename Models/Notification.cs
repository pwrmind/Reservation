using System;

namespace Reservation
{
    /// <summary>
    /// Represents a notification in the system.
    /// Notifications are used to inform users about various events,
    /// such as reservation status changes, resource availability, or system updates.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Unique identifier for the notification
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The content of the notification message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Foreign key to the recipient resource
        /// </summary>
        public string RecipientId { get; private set; }

        /// <summary>
        /// Navigation property to the recipient resource
        /// </summary>
        public Resource Recipient { get; private set; }

        /// <summary>
        /// Protected constructor for Entity Framework
        /// </summary>
        protected Notification()
        {
        }

        /// <summary>
        /// Creates a new notification
        /// </summary>
        /// <param name="recipientId">ID of the resource that will receive the notification</param>
        /// <param name="message">The content of the notification message</param>
        /// <exception cref="ArgumentException">Thrown when recipientId or message is null or empty</exception>
        public Notification(string recipientId, string message)
        {
            if (string.IsNullOrWhiteSpace(recipientId))
            {
                throw new ArgumentException("A recipient of null or empty was not allowed.", nameof(recipientId));
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("A message of null or empty was not allowed.", nameof(message));
            }           
            
            Id = Guid.NewGuid().ToString();
            Message = message;
            RecipientId = recipientId;
        }

        /// <summary>
        /// Sends the notification to the recipient
        /// </summary>
        public void Send()
        {
            Console.WriteLine("...Send...");
        }
    }
}