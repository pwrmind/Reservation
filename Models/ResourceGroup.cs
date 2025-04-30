using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservation
{
    /// <summary>
    /// Represents a group of resources in the system.
    /// Resource groups are used to organize resources based on various criteria,
    /// such as geographical location, department, or functional purpose.
    /// </summary>
    public class ResourceGroup
    {
        /// <summary>
        /// Unique identifier for the resource group
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Display name of the resource group
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Foreign key to the parent resource group
        /// </summary>
        public string ParentId { get; private set; }

        /// <summary>
        /// Navigation property to the parent resource group
        /// </summary>
        public ResourceGroup Parent { get; private set; }

        /// <summary>
        /// Protected constructor for Entity Framework
        /// </summary>
        protected ResourceGroup()
        {
        }

        /// <summary>
        /// Creates a new resource group
        /// </summary>
        /// <param name="name">Display name of the resource group</param>
        /// <param name="parentId">ID of the parent resource group (optional)</param>
        /// <exception cref="ArgumentException">Thrown when name is null or empty</exception>
        public ResourceGroup(string name, string parentId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name of null or empty was not allowed.", nameof(name));
            }
            
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.ParentId = parentId;
        }
    }
}