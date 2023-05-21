using System;

namespace Reservation
{
    public class ResourceType
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        protected ResourceType()
        {
        }
        public ResourceType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name of null or empty was not allowed.", nameof(name));
            }
            
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}