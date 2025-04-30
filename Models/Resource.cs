using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reservation
{
    /// <summary>
    /// Represents a reservable resource in the system.
    /// A resource can be any entity that needs to be reserved, such as a room, equipment, or service.
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Unique identifier for the resource
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Display name of the resource
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Foreign key to the resource type
        /// </summary>
        public string TypeId { get; private set; }

        /// <summary>
        /// Navigation property to the resource type
        /// </summary>
        public ResourceType Type { get; private set; }

        /// <summary>
        /// Foreign key to the resource group
        /// </summary>
        public string GroupId { get; private set; }

        /// <summary>
        /// Navigation property to the resource group
        /// </summary>
        public ResourceGroup Group { get; private set; }

        /// <summary>
        /// Foreign key to the resource source
        /// </summary>
        public string SourceId { get; private set; }

        /// <summary>
        /// Navigation property to the resource source
        /// </summary>
        public ResourceSource Source { get; private set; }

        /// <summary>
        /// Foreign key to the decision maker resource
        /// </summary>
        public string DecisionMakerId { get; private set; }

        /// <summary>
        /// Navigation property to the decision maker resource
        /// </summary>
        public Resource DecisionMaker { get; private set; }

        /// <summary>
        /// Foreign key to the owner resource
        /// </summary>
        public string OwnerId { get; private set; }

        /// <summary>
        /// Navigation property to the owner resource
        /// </summary>
        public Resource Owner { get; private set; }
        
        /// <summary>
        /// Collection of requests associated with this resource
        /// </summary>
        public ICollection<RequestResource> Requests { get; private set; }

        /// <summary>
        /// Protected constructor for Entity Framework
        /// </summary>
        protected Resource()
        {
        }
        
        /// <summary>
        /// Creates a new resource with the specified properties
        /// </summary>
        /// <param name="name">Display name of the resource</param>
        /// <param name="typeId">ID of the resource type</param>
        /// <param name="groupId">ID of the resource group</param>
        /// <param name="sourceId">ID of the resource source</param>
        /// <param name="decisionMakerId">ID of the decision maker resource</param>
        /// <param name="ownerId">ID of the owner resource</param>
        /// <exception cref="ArgumentException">Thrown when name is null or empty</exception>
        public Resource(string name, string typeId, string groupId, string sourceId, string decisionMakerId, string ownerId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("A name of null or empty was not allowed.", nameof(name));
            }
            
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.TypeId = typeId;
            this.GroupId = groupId;
            this.SourceId = sourceId;
            this.DecisionMakerId = decisionMakerId;
            this.OwnerId = ownerId;
        }
    }
}