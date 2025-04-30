using System;
using System.Collections.Generic;

namespace Reservation
{
    /// <summary>
    /// Represents a reservation request in the system.
    /// A request is made by a holder to reserve one or more resources for a specific time period.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Unique identifier for the request
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Foreign key to the holder resource
        /// </summary>
        public string HolderId { get; private set; }

        /// <summary>
        /// Navigation property to the holder resource
        /// </summary>
        public Resource Holder { get; private set; }

        /// <summary>
        /// Start date and time of the reservation
        /// </summary>
        public DateTime From { get; private set; }

        /// <summary>
        /// End date and time of the reservation
        /// </summary>
        public DateTime To { get; private set; }

        /// <summary>
        /// Reason for the reservation request
        /// </summary>
        public string Reason { get; private set; }

        /// <summary>
        /// Foreign key to the request status
        /// </summary>
        public string StatusId { get; private set; }

        /// <summary>
        /// Navigation property to the request status
        /// </summary>
        public RequestStatus Status {get; private set; }

        /// <summary>
        /// Collection of resources requested in this reservation
        /// </summary>
        public ICollection<RequestResource> Resources { get; private set; }
        
        /// <summary>
        /// Protected constructor for Entity Framework
        /// </summary>
        protected Request() { }

        /// <summary>
        /// Creates a new reservation request
        /// </summary>
        /// <param name="id">Optional request ID. If not provided, a new GUID will be generated</param>
        /// <param name="holder">The resource making the request</param>
        /// <param name="resources">List of resources to be reserved</param>
        /// <param name="from">Start date and time of the reservation</param>
        /// <param name="to">End date and time of the reservation</param>
        /// <param name="reason">Optional reason for the reservation</param>
        /// <exception cref="ArgumentNullException">Thrown when holder or resources is null</exception>
        public Request(string id, Resource holder, List<RequestResource> resources, DateTime from, DateTime to, string reason = "")
        {
            if (holder == null)
            {
                throw new ArgumentNullException("A holder of null was not allowed.", nameof(holder));
            }

            if (resources == null)
            {
                throw new ArgumentNullException("Resources of null was not allowed.", nameof(resources));
            }

            Id = id ?? Guid.NewGuid().ToString();
            Holder = holder;
            Resources = resources;
            From = from;
            To = to;
            Reason = reason;
        }
    }
}