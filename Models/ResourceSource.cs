using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservation
{
    /// <summary>
    /// Represents the source or origin of a resource in the system.
    /// Resource sources are used to track where resources come from,
    /// such as different departments, external providers, or locations.
    /// </summary>
    public class ResourceSource
    {
        /// <summary>
        /// Unique identifier for the resource source
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Display name of the resource source
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Protected constructor for Entity Framework
        /// </summary>
        protected ResourceSource()
        {
        }

        /// <summary>
        /// Creates a new resource source
        /// </summary>
        /// <param name="name">Display name of the resource source</param>
        /// <exception cref="ArgumentException">Thrown when name is null or empty</exception>
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