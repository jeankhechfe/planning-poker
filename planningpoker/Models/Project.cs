using System.Collections.Generic;

namespace planningpoker.Models
{
    public class Project
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Epic> Epics { get; set; }
        public ICollection<UserProjectPermission> UserProjectPermissions { get; set; }
    }
}