using System.Collections.Generic;

namespace planningpoker.Models
{
    public class Epic
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
