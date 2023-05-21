using System;

namespace Reservation
{
    public class Notification
    {
        public string Id { get; private set; }
        public string Message { get; private set; }
        public string RecipientId { get; private set; }
        public Resource Recipient { get; private set; }
        protected Notification()
        {
        }
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
    }
}