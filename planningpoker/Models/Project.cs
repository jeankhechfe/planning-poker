using System.Collections.Generic;

namespace planningpoker.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Epic> Epics { get; set; }
    }
}