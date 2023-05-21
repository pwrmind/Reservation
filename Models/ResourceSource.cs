using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservation
{
    public class ResourceSource
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        protected ResourceSource()
        {
        }
        public ResourceSource(string name)
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