using System.Collections.Generic;

namespace planningpoker.Models
{
    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int EpicId { get; set; }
        public Epic Epic { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
