using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planningpoker.Models
{
    public class Task
    {
        // [Key]
        public string TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FinalEstimation { get; set; }
        
        // public int EpicId { get; set; }
        // public Epic Epic { get; set; }
        
        public User User { get; set; }
        
        // public List<Comment> Comments { get; set; }
    }
}
