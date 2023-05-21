using System;
using System.Collections.Generic;

namespace Reservation
{
    public class Request
    {
        public string Id { get; private set; }
        public string HolderId { get; private set; }
        public Resource Holder { get; private set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public string Reason { get; private set; }
        public string StatusId { get; private set; }
        public RequestStatus Status {get; private set; }


        public ICollection<RequestResource> Resources { get; private set; }
        

        protected Request() { }

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