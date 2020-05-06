using System.Collections.Generic;

namespace planningpoker.Models
{
    public class Epic
    {
        public string EpicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Task> Tasks { get; set; }

    }
}
