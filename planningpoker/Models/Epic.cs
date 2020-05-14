using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace planningpoker.Models
{
    public class Epic
    {
        public string EpicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public Project Project { get; set; }
        
        public ICollection<Task> Tasks { get; set; }
    }
}
