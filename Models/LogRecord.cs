using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservation
{
    /// <summary>
    /// Represents a log record in the system.
    /// Log records are used to track and audit all significant actions and changes
    /// related to resource reservations and system operations.
    /// </summary>
    public class LogRecord
    {
        /// <summary>
        /// Unique identifier for the log record
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Foreign key to the associated request
        /// </summary>
        public string RequestId { get; private set; }

        /// <summary>
        /// Navigation property to the associated request
        /// </summary>
        public Request Request { get; private set; }

        /// <summary>
        /// Navigation property to the holder resource
        /// </summary>
        public Resource Holder { get; private set; }

        /// <summary>
        /// Navigation property to the reserved resource
        /// </summary>
        public Resource Resource { get; private set; }

        /// <summary>
        /// Start date and time of the reservation
        /// </summary>
        public DateTime From { get; private set; }

        /// <summary>
        /// End date and time of the reservation
        /// </summary>
        public DateTime To { get; private set; }

        /// <summary>
        /// Reason or description of the logged action
        /// </summary>
        public string Reason { get; private set; }

        /// <summary>
        /// Protected constructor for Entity Framework
        /// </summary>
        protected LogRecord() { }

        /// <summary>
        /// Creates a new log record
        /// </summary>
        /// <param name="requestId">ID of the associated request</param>
        /// <param name="holder">The resource making the request</param>
        /// <param name="resource">The resource being reserved</param>
        /// <param name="from">Start date and time of the reservation</param>
        /// <param name="to">End date and time of the reservation</param>
        /// <param name="reason">Optional reason or description</param>
        public LogRecord(string requestId, Resource holder, Resource resource, DateTime from, DateTime to, string reason = "")
        {
            Id = Guid.NewGuid().ToString();
            RequestId = requestId;
            Holder = holder;
            Resource = resource;
            From = from;
            To = to;
            Reason = reason;
        }
    }
}