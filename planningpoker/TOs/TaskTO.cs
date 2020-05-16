namespace planningpoker.TOs
{
    public class TaskTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Estimation { get; set; }

        public UserTO Assignee { get; set; }
        
        public ProjectTO Project { get; set; }
    }
}