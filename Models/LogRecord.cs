using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservation
{
    public class LogRecord
    {
        public string Id { get; private set; }
        public string RequestId { get; private set; }
        public Request Request { get; private set; }
        public Resource Holder { get; private set; }
        public Resource Resource { get; private set; }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public string Reason { get; private set; }

        protected LogRecord() { }

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