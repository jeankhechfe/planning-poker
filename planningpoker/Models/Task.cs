using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using planningpoker.TOs;

namespace planningpoker.Models
{
    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Estimation { get; set; }
        
        public string ProjectId { get; set; }
        public Project Project { get; set; }
        
        public string AssigneeId { get; set; }
        public User Assignee { get; set; }

        public TaskTO toTO()
        {
            return new TaskTO()
            {
                Id =  Id,
                Name = Name,
                Description = Description,
                Estimation = Estimation,
                Assignee = Assignee?.ToTo(),
                Project = Project?.toTO()
            };
        }
    }
}
