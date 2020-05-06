using System.Collections.Generic;

namespace planningpoker.Models
{
    public class Task
    {
        
        public string TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FinalEstimation { get; set; }
        public int EpicId { get; set; }
        public Epic Epic { get; set; }
        public List<User> Users { get; set; }
    }
}
