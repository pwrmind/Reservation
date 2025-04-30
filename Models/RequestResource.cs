using System.Text.Json.Serialization;

namespace Reservation
{
    /// <summary>
    /// Represents the many-to-many relationship between requests and resources.
    /// This class is used to track which resources are associated with each reservation request.
    /// </summary>
    public class RequestResource
    {
        /// <summary>
        /// Foreign key to the request
        /// </summary>
        public string RequestId { get; private set; }

        /// <summary>
        /// Navigation property to the request
        /// </summary>
        [JsonIgnore]
        public Request Request { get; private set; }

        /// <summary>
        /// Foreign key to the resource
        /// </summary>
        public string ResourceId { get; private set; }

        /// <summary>
        /// Navigation property to the resource
        /// </summary>
        public Resource Resource { get; private set; }

        /// <summary>
        /// Protected constructor for Entity Framework
        /// </summary>
        protected RequestResource()
        {
            
        }

        /// <summary>
        /// Creates a new request-resource relationship
        /// </summary>
        /// <param name="requestId">ID of the request</param>
        /// <param name="resourceId">ID of the resource</param>
        public RequestResource(string requestId, string resourceId)
        {
            this.RequestId = requestId;
            this.ResourceId = resourceId;
        }
    }
}