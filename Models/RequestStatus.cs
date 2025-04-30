using System;

namespace Reservation
{
    /// <summary>
    /// Represents the status of a reservation request in the system.
    /// Request statuses track the current state of a reservation request,
    /// such as pending, approved, rejected, or completed.
    /// </summary>
    public class RequestStatus
    {
        /// <summary>
        /// Unique identifier for the request status
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Display name of the request status
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Protected constructor for Entity Framework
        /// </summary>
        protected RequestStatus()
        {
        }

        /// <summary>
        /// Creates a new request status
        /// </summary>
        /// <param name="name">Display name of the request status</param>
        /// <exception cref="ArgumentException">Thrown when name is null or empty</exception>
        public RequestStatus(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name of null or empty was not allowed.", nameof(name));
            }
            
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
        }
    }
}