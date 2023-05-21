using System;

namespace Reservation
{
    public class RequestStatus
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        protected RequestStatus()
        {
        }
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