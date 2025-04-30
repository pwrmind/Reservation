using System;

namespace Reservation
{
    /// <summary>
    /// Represents a type or category of resources in the system.
    /// Resource types are used to categorize and group similar resources together.
    /// </summary>
    public class ResourceType
    {
        /// <summary>
        /// Unique identifier for the resource type
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Display name of the resource type
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Protected constructor for Entity Framework
        /// </summary>
        protected ResourceType()
        {
        }

        /// <summary>
        /// Creates a new resource type
        /// </summary>
        /// <param name="name">Display name of the resource type</param>
        /// <exception cref="ArgumentException">Thrown when name is null or empty</exception>
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