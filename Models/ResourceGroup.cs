using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservation
{
    // Группировка ресурсов(например по территориальной принадлежности)
    public class ResourceGroup
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string ParentId { get; private set; }
        public ResourceGroup Parent { get; private set; }
        protected ResourceGroup()
        {
        }
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