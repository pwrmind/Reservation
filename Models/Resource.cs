using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Reservation
{
    public class Resource
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string TypeId { get; private set; }
        public ResourceType Type { get; private set; }
        public string GroupId { get; private set; }
        public ResourceGroup Group { get; private set; }
        public string SourceId { get; private set; }
        public ResourceSource Source { get; private set; }
        public string DecisionMakerId { get; private set; }
        public Resource DecisionMaker { get; private set; }
        public string OwnerId { get; private set; }
        public Resource Owner { get; private set; }
        
        public ICollection<RequestResource> Requests { get; private set; }

        protected Resource()
        {
        }
        
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