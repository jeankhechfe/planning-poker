using System;
using planningpoker.TOs;

namespace planningpoker.Models
{
    public class UserTaskEstimation
    {
        public string Id { get; set; }
        public DateTimeOffset Updated { get; set; } //should be in ISO
        public int Estimation { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string TaskId { get; set; }
        public Task Task { get; set; }

        public UserTaskEstimationTO toTO()
        {
            return new UserTaskEstimationTO()
            {
                Id =  Id,
                Estimation = Estimation,
                Updated = Updated,
                User = User.ToTo(),
                Task = Task.toTO()
            };
        }
    }
}