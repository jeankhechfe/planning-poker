using System;

namespace planningpoker.TOs
{
    public class UserTaskEstimationTO
    {
        public string Id { get; set; }
        public int Estimation { get; set; }
        public DateTimeOffset Updated { get; set; } //should be in ISO

        public UserTO User { get; set; }
        public TaskTO Task { get; set; }
    }
}