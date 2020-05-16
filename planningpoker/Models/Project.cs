using System.Collections.Generic;
using planningpoker.TOs;

namespace planningpoker.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<UserProjectPermission> UserProjectPermissions { get; set; }

        public ProjectTO toTO()
        {
            return new ProjectTO()
            {
                Id = Id,
                Name = Name,
                Description = Description
            };
        }
    }
}