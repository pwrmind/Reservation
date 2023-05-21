using System.Text.Json.Serialization;

namespace Reservation
{
    public class RequestResource
    {
        public string RequestId { get; private set; }
        [JsonIgnore]
        public Request Request { get; private set; }
        public string ResourceId { get; private set; }
        public Resource Resource { get; private set; }

        protected RequestResource()
        {
            
        }

        public RequestResource(string requestId, string resourceId)
        {
            this.RequestId = requestId;
            this.ResourceId = resourceId;
        }
    }
}